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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace connect4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void C1_Click(object sender, RoutedEventArgs e)
        {
            C1R1.Fill = new SolidColorBrush(Colors.Red);
        }

        private void C2_Click(object sender, RoutedEventArgs e)
        {
            C2R1.Fill = new SolidColorBrush(Colors.Red);
        }

        private void C3_Click(object sender, RoutedEventArgs e)
        {
            C3R1.Fill = new SolidColorBrush(Colors.Red);
        }

        private void C4_Click(object sender, RoutedEventArgs e)
        {
            C4R1.Fill = new SolidColorBrush(Colors.Red);
        }

        private void C5_Click(object sender, RoutedEventArgs e)
        {
            C5R1.Fill = new SolidColorBrush(Colors.Red);
        }

        private void C6_Click(object sender, RoutedEventArgs e)
        {
            C6R1.Fill = new SolidColorBrush(Colors.Red);
        }

        private void C7_Click(object sender, RoutedEventArgs e)
        {
            C7R1.Fill = new SolidColorBrush(Colors.Red);
        }
    }
}
