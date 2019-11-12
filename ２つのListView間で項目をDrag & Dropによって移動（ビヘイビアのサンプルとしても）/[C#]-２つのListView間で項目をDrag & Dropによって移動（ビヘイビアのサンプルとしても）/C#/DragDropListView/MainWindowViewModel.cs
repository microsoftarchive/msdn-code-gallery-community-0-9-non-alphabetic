using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace DragDropListView
{
    /// <summary>
    /// MainWindowのViewModel
    /// </summary>
    class MainWindowViewModel
    {
       /// <summary>
       /// コンストラクタ
       /// </summary>
        public MainWindowViewModel()
        {
            //右のListViewのテストデータ生成
            Items右 = new ObservableCollection<Person>(Enumerable.Range(1, 5).Select(i => new Person { No = i, Name = "日本" + i.ToString() }));
            //左のListViewのテストデータ生成
            Items左 = new ObservableCollection<Person>(Enumerable.Range(1, 5).Select(i => new Person { No = i, Name = "Japan" + i.ToString() }));

            /* 今回はBeginDragのSpecificationsプロパティが指定されなかった場合のデフォルトの動作で良いので、ここで指定しない。
             * なお、以下をコメントアウトを外してもうまく動作するように実装しています。OnMouseDownメソッドのコメントアウトも外して下さい。         
             */
            // Drag時に実行されるイベントハンドラの定義
            //DragSpecifications = new BeginDragSpecifications();
            //DragSpecifications.MouseDown += OnMouseDown;
 
            //Drop時に実行されるイベントハンドラの定義
            DropSpecifications = new AcceptDropSpecifications();
            DropSpecifications.DragOver += OnDragOver;
            DropSpecifications.DragDrop += OnDragDrop;
        }


        #region プロパティ

        /// <summary>
        /// ListView右にバインドするコレクション
        /// </summary>
        public ObservableCollection<Person> Items右 { get; set; }

        /// <summary>
        /// ListView左にバインドするコレクション
        /// </summary>
        public ObservableCollection<Person> Items左 { get; set; }

        /// <summary>
        /// ListViewへのDrag時に実行される定義
        /// </summary>
        public BeginDragSpecifications DragSpecifications { get; private set; }

        /// <summary>
        /// ListViewへのDrop時に実行される定義
        /// </summary>
        public AcceptDropSpecifications DropSpecifications { get; private set; }

        #endregion

        #region イベントハンドラ

        /* 今回はBeginDragのSpecificationsプロパティが指定されなかった場合のデフォルトの動作で良いので、ここで指定しない。
         * なお、以下をコメントアウトを外してもうまく動作するように実装しています。 
         * Drag時に実行されるイベントハンドラの定義のコメントアウトも外して下さい。
         */
        //void OnMouseDown(object sender, MouseButtonEventArgs args)
        //{
        //    var lv = sender as ListView;

        //    int index = lv.GetItemIndexAtPoint<ListViewItem>(args.GetPosition(lv));

        //    if (index != -1)
        //    {
        //        lv.SelectedIndex = index;
        //    }
        //    else
        //    {
        //        return;
        //    }

        //    if (lv.SelectedItem != null)
        //    {
        //        var data = new DataObject();

        //        data.SetData(typeof(Person), lv.SelectedItem);
        //        data.SetData(typeof(ListView), sender);

        //        DragDrop.DoDragDrop(lv, data, DragDropEffects.Move);
        //    }
        //}

        /// <summary>
        /// ListView上にDragされてきた場合の動作を規定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnDragOver(object sender, DragEventArgs args)
        {
            //Drag動作がMoveであり、かつ、保持しているデータにPersonオブジェクトが含まれている場合
            if (args.AllowedEffects.HasFlag(DragDropEffects.Move) &&
                args.Data.GetDataPresent(typeof(Person)))
            {
                args.Effects = DragDropEffects.Move;
            }
            else
            {
                args.Effects = DragDropEffects.None;
            }
        }

        /// <summary>
        /// ListView上にDropされてきた場合の動作を規定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnDragDrop(object sender, DragEventArgs args)
        {
            var fromLv = args.Data.GetData(typeof(ListView)) as ListView;
            var toLv = args.Source as ListView;
            var item = args.Data.GetData(typeof(Person)) as Person;

            if (item != null)
            {
               ((ObservableCollection<Person>)toLv.ItemsSource).Add(item);
               ((ObservableCollection<Person>)fromLv.ItemsSource).Remove(item);
            }
        }

        #endregion
    }

}
