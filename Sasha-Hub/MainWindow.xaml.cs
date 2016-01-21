using System;
using System.Windows;
using System.Threading;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;
using System.Xml;
using System.Diagnostics;

namespace Sasha_Hub
{
    public partial class MainWindow : Window
    {
        private static BitmapImage sashaImage = new BitmapImage();
        private static BitmapImage sashaLoadingImage = new BitmapImage();
        public MainWindow()
        {
            InitializeComponent();
            #region SETUP
            if (sashaImage != null)
            {
                sashaLoadingImage.BeginInit();
                sashaLoadingImage.UriSource = new Uri(@"pack://siteoforigin:,,,/Resources/SashaLoading.gif");
                sashaLoadingImage.EndInit();
                sashaImage.BeginInit();
                sashaImage.UriSource = new Uri(@"pack://siteoforigin:,,,/Resources/Sasha.png");
                sashaImage.EndInit();
            }
            Tag.Source = sashaImage;
            #endregion
        }

        public void ToggleLoading()
        {
            if (Tag.Source == sashaImage)
            {
                ImageBehavior.SetAnimatedSource(Tag, sashaLoadingImage);
            }
            else
            {
                ImageBehavior.SetAnimatedSource(Tag, sashaImage);
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
                ConversationViewer.Text += $"{Environment.NewLine}You: {SayBox.Text}";
                string sashaMessage = Sasha.Interpret(SayBox.Text);
                SayBox.Text = "";
                if (sashaMessage != null)
                { // If its null its a command that doesn't return a message, like opening a webpage, or help
                    ToggleLoading();
                    Thread thread = new Thread(delegate ()
                    {
                        Thread.Sleep(sashaMessage.Length * 25); // Jokes were taking WAY to long so I changed this. Sorry.
                        this.Dispatcher.Invoke((Action)(() => {
                            ConversationViewer.Text += $"{Environment.NewLine}Sasha: {sashaMessage}";
                            ToggleLoading();
                        }));
                    });
                    thread.Start();
                }
            }
            else
            {
                MessageBox.Show("You must say something!");
            }
        }
    }
}
