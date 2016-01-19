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
    }
}
