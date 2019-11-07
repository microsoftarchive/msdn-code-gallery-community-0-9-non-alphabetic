namespace SyncListBox
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Data;

    public class MainWindowViewModel : ViewModelBase
    {
        // 全てのアイテムのViewSource
        private CollectionViewSource allItemsSource;
        // 選択中のアイテムのみ表示するViewSource
        private CollectionViewSource checkedItemsSource;
        // 元になるアイテムを持ったコレクション
        public ObservableCollection<Item> Items { get; private set; }

        // すべてのアイテム
        public ICollectionView AllItems
        {
            get
            {
                return this.allItemsSource.View;
            }
        }

        // チェックされたアイテム
        public ICollectionView CheckedItems
        {
            get
            {
                return this.checkedItemsSource.View;
            }
        }

        #region HaveCheckedItemプロパティ
        private bool _haveCheckedItem;

        // チェックされたアイテムがある場合にtrueを返す。
        public bool HaveCheckedItem
        {
            get { return _haveCheckedItem; }
            
            private set
            {
                if (Equals(_haveCheckedItem, value)) return;
                _haveCheckedItem = value;
                this.RaisePropertyChanged("HaveCheckedItem");
            }
        }
        #endregion


        public MainWindowViewModel()
        {
            // テスト用のデータ作成
            this.Items = new ObservableCollection<Item>
            {
                new Item { Label = "Item1" },
                new Item { Label = "Item2" },
                new Item { Label = "Item3" }
            };

            foreach (var item in this.Items)
            {
                // Checkedの状態が変更したタイミングでCheckedItemの表示の更新と
                // HaveCheckedItemの状態を更新する。
                item.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName != "Checked")
                    {
                        return;
                    }

                    this.CheckedItems.Refresh();
                    this.HaveCheckedItem = !this.CheckedItems.IsEmpty;
                };
            }

            // 全てのアイテムを表示するViewSourceを作成
            this.allItemsSource = new CollectionViewSource
            {
                Source = this.Items
            };

            // Checkedがtrueの項目だけ表示するViewSourceを作成
            this.checkedItemsSource = new CollectionViewSource
            {
                Source = this.Items
            };
            this.checkedItemsSource.Filter += (s, e) =>
            {
                var item = e.Item as Item;
                e.Accepted = item.Checked;
            };
        }
    }
}
