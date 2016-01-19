using System.Windows;

namespace Sasha_Hub
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Tag.Image = Sasha_Hub.Resources.Sasha;
        }

        public void ToggleLoading(bool isOn)
        {
            if (isOn == true)
            {
                Tag.Image = Sasha_Hub.Resources.SashaLoading;
            }
            else
            {
                Tag.Image = Sasha_Hub.Resources.Sasha;
            }
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow Settings = new SettingsWindow();
            Settings.Show();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You can save your file, IN HELL!");
        }

        private void Github_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/KampenRaddare/Sasha-Hub");
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow Help = new HelpWindow();
            Help.Show();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow About = new AboutWindow();
            About.Show();
        }

        private void Say_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
