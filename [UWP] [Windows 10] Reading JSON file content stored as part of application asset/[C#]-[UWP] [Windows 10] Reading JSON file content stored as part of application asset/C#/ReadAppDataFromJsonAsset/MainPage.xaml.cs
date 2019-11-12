using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections.ObjectModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ReadAppDataFromJsonAsset
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /* 
            To access access file from the application package where we dont know the root authority, we need to specify ms-appx
            For more details refer https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh965322.aspx
        */
        private string DefaultFileName = "ms-appx:///Assets/MyAppDefaultValues.Json";

        public MainPage()
        {
            this.InitializeComponent();
            LoadListContent();//Call to load the list with details from Json file
        }

        private void LoadListContent()
        {
            FileIOHelper oFileHelper = new FileIOHelper();
            List<SettingInfo> lstSettingInfo = oFileHelper.ReadFromDefaultFile(DefaultFileName);//Call to helper file for getting the details
            ObservableCollection<SettingInfo> oSettingsObserv = new ObservableCollection<SettingInfo>(lstSettingInfo);
            lstBookmarks.ItemsSource = oSettingsObserv;//Binding the values to list
        }
    }
}
