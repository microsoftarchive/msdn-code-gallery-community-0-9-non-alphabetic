using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DragDropListView
{
    /// <summary>
    /// 拡張メソッドの定義
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// クリックされた行のインデックスを求める。
        /// </summary>
        /// <typeparam name="T">クリックされた行の型</typeparam>
        /// <param name="ic">クリックされた行を内部に含むコントロール</param>
        /// <param name="pt">クリックされたPoint</param>
        /// <returns>クリックされた行のインデックス。見つからなければ -1を返す。</returns>
        public static int GetItemIndexAtPoint<T>(this ItemsControl ic, Point pt)
                          where T : DependencyObject
        {
            HitTestResult result = VisualTreeHelper.HitTest(ic, pt);
            DependencyObject obj = result.VisualHit;

            while (obj != null && !(obj is T))
            {
                obj = VisualTreeHelper.GetParent(obj);
            }

            if (obj != null)
            {
                return ic.Items.IndexOf((obj as dynamic).Content);
            }

            return -1;
        }
    }
}
