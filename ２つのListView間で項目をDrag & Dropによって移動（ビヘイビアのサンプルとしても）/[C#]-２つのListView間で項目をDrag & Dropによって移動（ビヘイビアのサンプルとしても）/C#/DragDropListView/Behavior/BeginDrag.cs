using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace DragDropListView
{
    /// <summary>
    /// Dragを開始した際の動作を定義するビヘイビア
    /// 
    /// ＃Behaviorクラスを使用するためにSystem.Windows.Interactivityの参照設定が必要。
    /// </summary>
    public class BeginDrag : Behavior<FrameworkElement>
    {
        #region 依存関係プロパティ

        /// <summary>
        /// AllowedEffects Drag & Dropのモード（copy, move, ...etc)
        /// </summary>
        public static readonly DependencyProperty AllowedEffectsProperty =
            DependencyProperty.Register("AllowedEffects", typeof(DragDropEffects),
            typeof(BeginDrag), new UIPropertyMetadata(DragDropEffects.All));

        public DragDropEffects AllowedEffects
        {
            get { return (DragDropEffects)GetValue(AllowedEffectsProperty); }
            set { SetValue(AllowedEffectsProperty, value); }
        }

        /// <summary>
        /// Specifications Dragを開始した際の動作を定義したクラスを保持するプロパティ
        /// </summary>
        public static readonly DependencyProperty SpecificationsProperty =
            DependencyProperty.Register("Specifications", typeof(BeginDragSpecifications),
            typeof(BeginDrag), new PropertyMetadata(null));

        public BeginDragSpecifications Specifications
        {
            get { return (BeginDragSpecifications)GetValue(SpecificationsProperty); }
            set { SetValue(SpecificationsProperty, value); }
        }

        #endregion ---------------------------------------------------------------------

        protected override void OnAttached()
        {
            this.AssociatedObject.PreviewMouseDown += PreviewMouseDown;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.PreviewMouseDown -= PreviewMouseDown;
        }

        void PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var sc = Specifications;

            if (sc != null)
            {
                sc.OnMouseDown(sender, e);
                e.Handled = true;
            }
            else
            {
                //BeginDragSpecificationsが指定されなかった場合のデフォルト動作を定義する。
                switch (sender.GetType().Name)
                {
                    case "ListView":

                        var lv = this.AssociatedObject as ListView;

                        int index = lv.GetItemIndexAtPoint<ListViewItem>(e.GetPosition(lv));

                        if (index != -1)
                        {
                            lv.SelectedIndex = index;

                            var data = new DataObject();

                            data.SetData(typeof(Person), lv.SelectedItem);
                            data.SetData(typeof(ListView), this.AssociatedObject);

                            DragDrop.DoDragDrop(lv, data, this.AllowedEffects);
                        }

                        break;
                }
            }
        }

    }
}
