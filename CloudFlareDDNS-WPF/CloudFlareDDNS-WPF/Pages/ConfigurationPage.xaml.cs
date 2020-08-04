using CloudFlareDDNS_WPF.Config;
using System.Windows;
using System.Windows.Controls;

namespace CloudFlareDDNS_WPF.Pages
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class ConfigurationPage : Page
    {
        public ConfigurationPage()
        {
            InitializeComponent();
            this.X_AUTH_KEY_Box.Text = UserConfiguration.xauth_key;
            this.Zone_ID_Box.Text = UserConfiguration.zone_id;
            this.Email_Box.Text = UserConfiguration.xauth_email;
            this.Website_URL_Box.Text = UserConfiguration.record_name;
            this.AutoStartSwitch.IsOn = UserConfiguration.auto_start;
            this.AutoStartUpSwitch.IsOn = UserConfiguration.auto_activate;
        }

        private void X_AUTH_KEY_Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserConfiguration.xauth_key = (sender as TextBox).Text;
        }

        private void Zone_ID_Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserConfiguration.zone_id = (sender as TextBox).Text;
        }

        private void Email_Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserConfiguration.xauth_email = (sender as TextBox).Text;
        }

        private void Website_URL_Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserConfiguration.record_name = (sender as TextBox).Text;
        }

        private void AutoStartSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            UserConfiguration.auto_start = (sender as MahApps.Metro.Controls.ToggleSwitch).IsOn;
        }

        private void AutoStartUpSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            UserConfiguration.auto_activate = (sender as MahApps.Metro.Controls.ToggleSwitch).IsOn;
        }

        private void OpenAPIConfiguration(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer", "/select," + CfDdnsProperty.CONFIG_FILE_PATH + CfDdnsProperty.CONFIG_API_FILE_NAME);
        }

        private void ResetAPIConfiguraion(object sender, RoutedEventArgs e)
        {
            Lib.Helper.ResetAPIConfiguration();
        }
    }
}
