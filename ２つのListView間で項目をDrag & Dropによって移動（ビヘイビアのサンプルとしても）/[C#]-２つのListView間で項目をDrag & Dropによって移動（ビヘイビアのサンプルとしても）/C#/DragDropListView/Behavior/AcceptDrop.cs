using System.Windows;
using System.Windows.Interactivity;

namespace DragDropListView
{
    /// <summary>
    /// Dropされた際の動作を定義するビヘイビア
    /// 
    /// ＃Behaviorクラスを使用するためにSystem.Windows.Interactivityの参照設定が必要。
    /// </summary>
	public class AcceptDrop : Behavior<FrameworkElement>
	{
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AcceptDrop()
		{
            //WindowにDropされた際に、その上のコントロールにもイベントを伝えたい場合はfalseにセット。
            DropHandled = true;
			DragOverHandled = true;
		}

        #region 依存関係プロパティ
 
        /// <summary>
        /// Specifications Dropされた際などの動作を定義したクラスを受け取るプロパティ
        /// </summary>
        public static readonly DependencyProperty SpecificationsProperty =
            DependencyProperty.Register("Specifications", typeof(AcceptDropSpecifications),
			typeof(AcceptDrop), new PropertyMetadata(null));

        public AcceptDropSpecifications Specifications
        {
            get { return (AcceptDropSpecifications)GetValue(SpecificationsProperty); }
            set { SetValue(SpecificationsProperty, value); }
        }

        /// <summary>
        /// DropHandled
        /// </summary>
		public static readonly DependencyProperty DropHandledProperty =
			DependencyProperty.Register("DropHandled", typeof(bool),
			typeof(AcceptDrop), new PropertyMetadata(null));

        public bool DropHandled
        {
            get { return (bool)GetValue(DropHandledProperty); }
            set { SetValue(DropHandledProperty, value); }
        }        

		/// <summary>
        /// DragOverHandled
		/// </summary>
        public static readonly DependencyProperty DragOverHandledProperty =
			DependencyProperty.Register("DragOverHandled", typeof(bool),
			typeof(AcceptDrop), new PropertyMetadata(null));

        public bool DragOverHandled
        {
            get { return (bool)GetValue(DragOverHandledProperty); }
            set { SetValue(DragOverHandledProperty, value); }
        }

        #endregion ------------------------------------------------------------------

        protected override void OnAttached()
		{
			this.AssociatedObject.PreviewDragOver += DragOver;
			this.AssociatedObject.PreviewDrop += Drop;
			base.OnAttached();
		}

        protected override void OnDetaching()
		{
			this.AssociatedObject.PreviewDragOver -= DragOver;
			this.AssociatedObject.PreviewDrop -= Drop;
			base.OnDetaching();
		}

		void DragOver(object sender, DragEventArgs e)
		{
			var sc = Specifications;

            if (sc != null)
            {
                sc.OnDragOver(sender, e);
                e.Handled = DragOverHandled;
            }
            else
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }

		}

		void Drop(object sender, DragEventArgs e)
		{
			var sc = Specifications;

			if (sc != null)
			{
                sc.OnDrop(sender, e);
                e.Handled = DropHandled;
            }
            else
            {
                e.Effects = DragDropEffects.None;
				e.Handled = true;
			}
		}
	}
}
