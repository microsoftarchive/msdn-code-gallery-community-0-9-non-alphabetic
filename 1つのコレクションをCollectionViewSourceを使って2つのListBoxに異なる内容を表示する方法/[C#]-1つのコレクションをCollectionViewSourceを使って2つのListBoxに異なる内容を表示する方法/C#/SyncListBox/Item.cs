namespace SyncListBox
{
    /// <summary>
    /// ListBoxに表示するアイテム
    /// </summary>
    public class Item : ViewModelBase
    {
        #region Labelプロパティ
        private string _label;
        public string Label
        {
            get { return _label; }
            set
            {
                if (Equals(_label, value)) return;
                _label = value;
                this.RaisePropertyChanged("Label");
            }
        }
        #endregion

        #region Checkedプロパティ
        private bool _checked;
        public bool Checked
        {
            get { return _checked; }
            set
            {
                if (Equals(_checked, value)) return;
                _checked = value;
                this.RaisePropertyChanged("Checked");
            }
        }
        #endregion

    }
}
