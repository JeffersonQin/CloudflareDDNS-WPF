using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CloudFlareDDNS_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        // 包含所有页面的一个字典
        private Dictionary<string, Uri> ddnsViews = new Dictionary<string, Uri>();

        public MainWindow()
        {
            InitializeComponent();

            #region UI初始化
            this.Title = CfDdnsProperty.SHOW_NAME;
            #endregion

            #region 系统托盘
            
            #endregion

            #region 页面导航初始化
            ddnsViews.Add("Configuration", new Uri("Pages/ConfigurationPage.xaml", UriKind.Relative));
            ddnsViews.Add("Console", new Uri("Pages/ConsolePage.xaml", UriKind.Relative));
            navigationFrame.Navigate(ddnsViews["Configuration"]);
            #endregion
        }

        private void LaunchGitHubSite(object sender, RoutedEventArgs e)
        {
            // Launch the GitHub site...
            Helper.OpenWebsite(CfDdnsProperty.HOME_PAGE);
        }
        private void LaunchAboutWindow(object sender, RoutedEventArgs e)
        {
            // Launch the About Window
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }

        private void ShowConfiguration(object sender, RoutedEventArgs e)
        {
            // Navigate
            navigationFrame.Navigate(ddnsViews["Configuration"]);
            // TODO：密码框载入（Navigate后会消失）
        }

        private void ShowConsole(object sender, RoutedEventArgs e)
        {
            // Navigate
            navigationFrame.Navigate(ddnsViews["Console"]);
            // TODO：密码框载入（Navigate后会消失）
        }

        private void DDNSOperation(object sender, RoutedEventArgs e)
        {
            
            if ((string)DDNSButton.Content == "▶  Start DDNS")
            {
                DDNSButton.Content = "█  Stop DDNS";
                DDNSButton.Background = new SolidColorBrush(Color.FromRgb(205, 92, 92));
                DDNSButton.BorderBrush = new SolidColorBrush(Color.FromRgb(205, 92, 92));
            } else
            {
                DDNSButton.Content = "▶  Start DDNS";
                DDNSButton.Background = new SolidColorBrush(Color.FromRgb(60, 179, 113));
                DDNSButton.BorderBrush = new SolidColorBrush(Color.FromRgb(60, 179, 113));
            }
        }

    }
}
