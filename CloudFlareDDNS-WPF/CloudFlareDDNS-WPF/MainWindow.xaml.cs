using CloudFlareDDNS_WPF.Config;
using CloudFlareDDNS_WPF.Lib;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;

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

            #region 查看API文件是否存在
            if (!File.Exists(CfDdnsProperty.CONFIG_FILE_PATH + CfDdnsProperty.CONFIG_API_FILE_NAME))
            {
                Helper.ResetAPIConfiguration();
            }
            #endregion

            #region 读取XML中的Config信息
            XMLReader<UserConfigurationData>.read(CfDdnsProperty.CONFIG_FILE_PATH, CfDdnsProperty.CONFIG_FILE_NAME).save();
            #endregion

            #region 退出询问
            this.Closing += Window_Closing;
            #endregion

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
            XMLWriter<UserConfigurationData>.write(UserConfiguration.GetUserConfigurationData(), CfDdnsProperty.CONFIG_FILE_PATH, CfDdnsProperty.CONFIG_FILE_NAME);
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            if (MessageBox.Show("Do you really want to quit?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                e.Cancel = false;
                XMLWriter<UserConfigurationData>.write(UserConfiguration.GetUserConfigurationData(), CfDdnsProperty.CONFIG_FILE_PATH, CfDdnsProperty.CONFIG_FILE_NAME);
            }
            else
            {
                e.Cancel = true;
            }
        }

    }
}
