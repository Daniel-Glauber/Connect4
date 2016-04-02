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
using System.Reflection;
using Microsoft.Win32;
using System.Diagnostics;

namespace connect4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Ellipse[,] ar;
        public MainWindow()
        {
            InitializeComponent();
            CreateDynamicStackPanel(7, 10);
        }

        private void CreateDynamicStackPanel(int rowSize, int colSize)
        {
            ar = new Ellipse[colSize, rowSize];
            Rectangle b = new Rectangle();

            b.Width = (colSize * 50 + (colSize + 1) * 10);
            b.Height = (rowSize * 50 + (rowSize + 1) * 10);
            b.Fill = new SolidColorBrush(Colors.Yellow);
            Board.Children.Add(b);
            for (int j = 0; j < colSize; j++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("C");
                sb.Append(j);
                StackPanel g = new StackPanel();
                g.VerticalAlignment = VerticalAlignment.Top;
                //g.VerticalOffset = 10;
                g.Orientation = Orientation.Vertical;
                g.Name = sb.ToString();
                //g.Width = 60;
                // g.Margin.Top = 
                for (int i = 0; i < rowSize; i++)
                {
                    StringBuilder ssb = new StringBuilder();
                    ssb.Append("C");
                    ssb.Append(j);
                    ssb.Append("R");
                    ssb.Append(i);
                    Ellipse redCircle = new Ellipse();
                    redCircle.Width = 50;
                    redCircle.Height = 50;
                    redCircle.Name = ssb.ToString();
                    redCircle.Fill = new SolidColorBrush(Colors.White);
                    //redCircle.Margin = new Thickness(10);
                    ar[j, i] = redCircle;
                    g.Children.Add(redCircle);
                }
                SideR.Children.Add(g);
            }

            root.Height = rowSize * 60 + 50 + 35; //(rowSize + 1) * 10;
            root.Width = 150 + colSize * 60 + 55;//(colSize + 1) * 10;
            Canvas.Margin = new Thickness(15, 15, 15, 15);
            // Console.WriteLine(SideR.Width);
            StackPanel file = new StackPanel();
            file.Orientation = Orientation.Horizontal;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ar[0, 1].Fill = new SolidColorBrush(Colors.Red);
        }

        private void filePath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Select Computer Player";
            fDialog.Filter = "Exe Files|*.exe";
            bool? userClickedOK = fDialog.ShowDialog();
            if (userClickedOK == true)
            {
                Console.WriteLine(fDialog.FileName.ToString());
                Process test = new Process();
                test.StartInfo.FileName = (fDialog.FileName.ToString());
                test.StartInfo.RedirectStandardOutput = false;
                test.StartInfo.UseShellExecute = false;
                test.StartInfo.CreateNoWindow = true;
                test.Start();
            }
        }
    }
}
