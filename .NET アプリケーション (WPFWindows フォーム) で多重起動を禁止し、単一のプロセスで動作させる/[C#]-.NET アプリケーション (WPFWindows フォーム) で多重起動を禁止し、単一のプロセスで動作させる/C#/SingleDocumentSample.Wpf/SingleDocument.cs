// 多重起動を禁止する
// - 他のプロセスが起動していなければ、普通にドキュメントを開く。
// - 他のプロセスが既に起動していれば、その起動中のアプリケーションでドキュメントを開く。
// WPF、Windows フォーム非依存
// 参照設定 System.Runtime.Remoting が必要

using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Threading;

namespace SingleDocumentSample
{
    // .NET で多重起動しないアプリケーションを作成するためのクラス (WPF、Windows フォーム非依存)
    public class SingleDocumentHelper
    {
        // 複数のプロセスで一つしかないことを保証する
        class Singleton : IDisposable
        {
            readonly Mutex mutex = null; // 複数のプロセスから参照するために Mutex を使用

            public bool IsExist // 既に存在しているかどうか
            {
                get
                {
                    return !mutex.WaitOne(0, false); // Mutex が既に作成されていたら true
                }
            }

            public Singleton(string uniqueName)
            {
                mutex = new Mutex(false, uniqueName); // コンストラクターで、このアプリケーション独自の名前で Mutex を作成
            }

            public void Dispose()
            { mutex.Dispose(); }
        }

        // Ipc によって複数のプロセスで共有するアイテムを格納する
        class IpcRemoteObject : MarshalByRefObject
        {
            public object Item { get; set; }

            // IpcRemoteObject に複数のプロセスで共有するアイテムを格納
            public static void Send(string channelName, string itemName, object item)
            {
                var channel = new IpcClientChannel(); // IPC (プロセス間通信) クライアント チャンネルの生成
                ChannelServices.RegisterChannel(channel, true); // チャンネルを登録
                var remoteObject = Activator.GetObject(typeof(IpcRemoteObject), string.Format("ipc://{0}/{1}", channelName, itemName)) as IpcRemoteObject; // リモートオブジェクトを取得
                if (remoteObject != null)
                    remoteObject.Item = item;
            }
        }

        // 指定された時間毎に Tick イベントが起きるオブジェクトのインタフェイス
        // アプリケーション側で実装する
        public interface ITicker : IDisposable
        {
            event Action Tick;

            void Start();
        }

        // 指定された時間毎に IpcRemoteObject をチェックし、空でなければ Receive イベントが起きる
        class Receiver : IDisposable
        {
            public event Action<object> Receive;

            IpcRemoteObject remoteObject;
            readonly ITicker ticker;

            public Receiver(string uniqueName, string itemName, ITicker ticker)
            {
                Initialize(uniqueName, itemName);
                this.ticker = ticker;
                ticker.Tick += OnTick;
                ticker.Start();
            }

            public void Dispose()
            { ticker.Dispose(); }
            
            void Initialize(string uniqueName, string itemName)
            {
                var channel = new IpcServerChannel(uniqueName); // このアプリケーション独自の名前で IPC (プロセス間通信) サーバー チャンネルを作成
                ChannelServices.RegisterChannel(channel, true); // チャンネルを登録
                remoteObject = new IpcRemoteObject(); // リモートオブジェクトを生成
                RemotingServices.Marshal(remoteObject, itemName, typeof(IpcRemoteObject)); // リモートオブジェクトを公開
            }

            void OnTick()
            {
                if (remoteObject.Item != null) { // リモートオブジェクトがあれば
                    if (Receive != null)
                        Receive(remoteObject.Item); // Receive イベントを起こす
                    remoteObject.Item = null;
                }
            }
        }

        // 多重起動しないアプリケーション (他のプロセスが起動済みの場合は、その起動済みのプロセスにドキュメントを開かせ、終了する)
        public class Application : IDisposable
        {
            const string itemName = "DocumentPathName";

            Singleton singleton = null;
            Receiver receiver = null;

            // 初期化 (戻り値が偽の場合は終了)
            public bool Initialize(ITicker ticker, string documentPath = "", Action<string> open = null)
            {
                var applicationProductName = ((AssemblyProductAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyProductAttribute))).Product;

                singleton = new Singleton(applicationProductName);
                if (singleton.IsExist) { // 既に他のプロセスが起動していたら
                    IpcRemoteObject.Send(applicationProductName, itemName, documentPath); // その起動済みのプロセスにドキュメントのパスを送信して
                    return false; // 終了する
                }
                receiver = new Receiver(applicationProductName, itemName, ticker);
                if (open != null) {
                    receiver.Receive += item => open((string)item); // Receive イベントが起きたらアイテムを open するように設定
                    if (!string.IsNullOrWhiteSpace(documentPath)) // documentPath が空でなければ
                        open(documentPath); // documentPath を開く
                }
                return true; // 終了しない
            }

            public void Dispose()
            {
                if (receiver != null) {
                    receiver.Dispose();
                    receiver = null;
                }
                if (singleton != null) {
                    singleton.Dispose();
                    singleton = null;
                }
            }
        }
    }
}
