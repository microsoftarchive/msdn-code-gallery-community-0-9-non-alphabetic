using Codeplex.Reactive;
using Codeplex.Reactive.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromObjectSample
{
    public class MainWindowViewModel
    {
        private Person p = new Person { Name = "tanaka" };

        public ReactiveProperty<string> OneWay { get; private set; }

        public ReactiveProperty<string> TwoWay { get; private set; }

        public ReactiveProperty<string> TwoWayConvert { get; private set; }

        public ReactiveProperty<string> ManualTwoWay { get; private set; }

        public ReactiveCommand ResetNameCommand { get; private set; }

        public MainWindowViewModel()
        {
            // ソースからターゲットへの一方通行の値の伝搬
            this.OneWay = this.p.ObserveProperty(x => x.Name).ToReactiveProperty();

            // 単純な双方向の値の伝搬
            this.TwoWay = this.p.ToReactivePropertyAsSynchronized(x => x.Name);

            // 値の変換を伴った双方向の値の伝搬
            this.TwoWayConvert = this.p.ToReactivePropertyAsSynchronized(x => x.Name,
                // ソースからターゲットにわたるときの値の変換
                x => x + "さん",
                // ターゲットからソースにわたるときの値の変換
                x => x.Replace("さん", ""));

            // 一方通行とSubscribeを組み合わせて双方向の値の伝搬
            this.ManualTwoWay = this.p.ObserveProperty(x => x.Name).ToReactiveProperty();
            this.ManualTwoWay.Subscribe(x => this.p.Name = x);

            // 名前をリセットするためのコマンド
            this.ResetNameCommand = new ReactiveCommand();
            this.ResetNameCommand.Subscribe(_ =>
                this.p.Name = "tanaka");
        }
    }
}
