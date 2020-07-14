using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CloudFlareDDNS_WPF
{
    /// <summary>
    /// AboutWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AboutWindow : MetroWindow
    {
        public AboutWindow()
        {
            InitializeComponent();
            TitleText.Text = CfDdnsProperty.SHOW_NAME;
            VersionText.Text = CfDdnsProperty.VERSION_CODE;
        }

        private void HomepageText_Click(object sender, RoutedEventArgs e)
        {
            Helper.OpenWebsite(CfDdnsProperty.HOME_PAGE);
        }
    }
}
