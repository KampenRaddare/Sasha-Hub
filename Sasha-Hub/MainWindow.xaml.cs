using System.Windows;

namespace Sasha_Hub
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loading.Image = Sasha_Hub.Resources.SashaLoading;
        }
        public void ToggleLoading()
        {
            if(Loading.Visible) {
                Loading.Visible = false;
                image.Visibility = Visibility.Visible;
            } else {
                Loading.Visible = true;
                image.Visibility = Visibility.Hidden;
            }
        }
    }
}
