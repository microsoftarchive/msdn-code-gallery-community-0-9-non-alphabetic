using System;
using System.Windows.Input;

namespace DragDropListView
{
    /// <summary>
    ///  BeginDragビヘイビアに渡す定義を保持するクラス
    /// </summary>
    public class BeginDragSpecifications
    {
        public event Action<object, MouseButtonEventArgs> MouseDown;

        public void OnMouseDown(object sender, MouseButtonEventArgs args)
        {
            var handler = MouseDown;

            if (handler != null)
                handler(sender, args);
        }
    }
}
