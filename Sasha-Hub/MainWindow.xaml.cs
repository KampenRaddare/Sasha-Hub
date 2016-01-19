using System.Windows;

namespace Sasha_Hub
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            #region SETUP
            Tag.Image = Sasha_Hub.Resources.Sasha;
            #endregion
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
            // Opens the settings window
            SettingsWindow Settings = new SettingsWindow();
            Settings.Show();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You can save your file, IN HELL!");
        }

        private void Github_Click(object sender, RoutedEventArgs e)
        {
            // Takes user to Github Project
            System.Diagnostics.Process.Start("https://github.com/KampenRaddare/Sasha-Hub");
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            // Opens the help window
            HelpWindow Help = new HelpWindow();
            Help.Show();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            // Opens the about window
            AboutWindow About = new AboutWindow();
            About.Show();
        }

        private void Say_Click(object sender, RoutedEventArgs e)
        {
            // Conversation Logic
            if (SayBox.Text != "")
            {
                ConversationViewer.Text += "\n" + "You: " + SayBox.Text;
                ConversationViewer.Text += "\n" + "Sasha: " + Sasha.Interpret(SayBox.Text);
                SayBox.Text = "";
            }
            else
            {
                MessageBox.Show("You must say something!");
            }
        }
    }
}
