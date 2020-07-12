using MahApps.Metro.Controls;
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
        public MainWindow()
        {
            InitializeComponent();
            this.Title = CfDdnsProperty.SHOW_NAME;
        }

        private void LaunchGitHubSite(object sender, RoutedEventArgs e)
        {
            // Launch the GitHub site...
            var psi = new ProcessStartInfo
            {
                FileName = CfDdnsProperty.HOME_PAGE,
                UseShellExecute = true
            };
            Process.Start(psi);
        }
        private void LaunchAboutWindow(object sender, RoutedEventArgs e)
        {
            // Launch the About Window
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }


    }
}
