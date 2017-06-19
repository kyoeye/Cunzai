using Cunzai.P;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Cunzai
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static MainPage Current;

        public MainPage()
        {
            this.InitializeComponent();
            Current = this;
            DetailFrame.Navigated += DetailFrame_Navigated;
            MasterFrame.Navigated += MasterFrame_Navigated;
            SystemNavigationManager.GetForCurrentView().BackRequested += View_BackRequested;
        }

        private void View_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (DetailFrame.CanGoBack)
            {
                DetailFrame.GoBack();
                e.Handled = true;
            }
            else if (MasterFrame.CanGoBack)
            {
                MasterFrame.GoBack();
                e.Handled = true;
            }
        }

        private void MasterFrame_Navigated(object sender, NavigationEventArgs e)
        {
            UpdateUI();

        }

        private void DetailFrame_Navigated(object sender, NavigationEventArgs e)
        {
               while (DetailFrame.BackStack.Count > 1)
            {
                DetailFrame.BackStack.RemoveAt(1);
            }
            UpdateUI();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MasterFrame.Navigate(typeof(MasterPage));
            DetailFrame.Navigate(typeof(NullPage));

        }

        private void AdaptiveStates_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            UpdateUI();

        }
        private void UpdateUI()
        {
            if (AdaptiveStates.CurrentState.Name == "NarrowState")
            {
                DetailFrame.Visibility = DetailFrame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
            }

            else if (AdaptiveStates.CurrentState.Name == "DefaultState")
            {
                if (DetailFrame.Visibility !=Visibility.Visible)
                {
                    DetailFrame.Visibility = Visibility.Visible;

                }
            }
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = DetailFrame.CanGoBack || MasterFrame.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }
    }
}
