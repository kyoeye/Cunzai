using Cunzai.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Cunzai.P
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MasterPage : Page
    {
        public MasterPage()
        {
            this.InitializeComponent();
            mainlistsetcontent();
        }

         List<MainList> MainLists;
        public void mainlistsetcontent()
        {
            int a;
            MainLists = new List<MainList>();
            for (a = 0; a<20; a++)
            {
                MainLists.Add(new MainList { ID = a });
            }
            //return MainLists;
        }
 
        private void Picturegrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //看下demo的源码
            var  boxs = sender as StackPanel ;
            var box = boxs.DataContext as MainList;
            MainPage.Current.DetailFrame.Navigate(typeof(BETApage),box.ID);
        }
    }
}
