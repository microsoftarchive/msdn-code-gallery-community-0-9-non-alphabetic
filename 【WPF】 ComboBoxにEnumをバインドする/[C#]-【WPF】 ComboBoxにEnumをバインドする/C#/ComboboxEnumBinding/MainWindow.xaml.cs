using System.Windows;

namespace ComboboxEnumBinding
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bttn_SelectRed_Click(object sender, RoutedEventArgs e)
        {
            comb_color.SelectedItem = ColorEnum.Red;
        }

        private void bttn_ShowSelectedColor_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(comb_color.SelectedItem.ToString());
        }
    }
    public enum ColorEnum
    {
        White = 0,
        Blue = 1,
        Red = 2,
        Black = 3
    }
}
