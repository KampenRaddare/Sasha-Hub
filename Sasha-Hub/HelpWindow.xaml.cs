using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Sasha_Hub
{
    /// <summary>
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Usage: Calcuate 2 2 or Calculate 2 *operation in words* 2", "Calculate");
        }

        private void Get_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Usage: Get Weather", "Get");
        }

        private void Define_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Usage: Define *Word*", "Define");
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Usage: Help or Help *Command*", "Help");
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Usage: Find *Search Term*", "Find");
        }

        private void Make_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Usage: Make Joke", "Make");
        }
    }
}
