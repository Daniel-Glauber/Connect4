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
using System.Drawing;
using System.Windows.Markup;

namespace connect4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int Column = 7;
        private static int Row = 6;
        public Ellipse[,] ar;
        board_controller board = new board_controller(Row, Column, "Red");
        public MainWindow()
        {
            InitializeComponent();

            CreateDynamicStackPanel(6, 7);
        }

        public MainWindow(int col, int row)
        {
            Column = col;
            Row = row;
            board = new board_controller(Row, Column, "Red");
            InitializeComponent();

            CreateDynamicStackPanel(row, col);
        }

        private void CreateDynamicStackPanel(int rowSize, int colSize)
        {
            ar = new Ellipse[colSize, rowSize];
            System.Windows.Shapes.Rectangle b = new System.Windows.Shapes.Rectangle();

            b.Width = (colSize * 50 + (colSize + 1) * 10);
            b.Height = (rowSize * 50 + (rowSize + 1) * 6) + 25;
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
                string buttonName = sb.ToString();

                Button btn = new Button();
                {
                    btn.Name = "Btn" + buttonName;
                    btn.Height = 20;
                    btn.Width = 50;
                    btn.Foreground = new SolidColorBrush(Colors.White);
                    btn.Margin = new Thickness(10, 5, 0, 2.5);
                    // btn.IsHitTestVisible = false;
                    btn.Click += button_Click;

                    ControlTemplate controlTemplate = new ControlTemplate(typeof(Button));

                    PointCollection points = new PointCollection(new List<System.Windows.Point> { new System.Windows.Point() { X = 0, Y = 0 }, new System.Windows.Point() { X = 50, Y = 0 }, new System.Windows.Point() { X = 25, Y = 20 } });
                    var polygon = new FrameworkElementFactory(typeof(Polygon));

                    polygon.SetValue(Polygon.PointsProperty, points);
                    polygon.SetValue(Polygon.FillProperty, new SolidColorBrush(Colors.Black));

                    var contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));

                    var grid = new FrameworkElementFactory(typeof(Grid));
                    grid.SetValue(Grid.BackgroundProperty, new SolidColorBrush(Colors.Yellow));
                    grid.AppendChild(polygon);
                    grid.AppendChild(contentPresenter);
                    controlTemplate.VisualTree = grid;
                    btn.Template = controlTemplate;
                }

                g.Children.Add(btn);
                for (int i = 0; i < rowSize; i++)
                {
                    StringBuilder ssb = new StringBuilder();
                    ssb.Append("C");
                    ssb.Append(j);
                    buttonName = ssb.ToString();
                    ssb.Append("R");
                    ssb.Append(i);
                    Ellipse redCircle = new Ellipse();
                    redCircle.Width = 50;
                    redCircle.Height = 50;
                    redCircle.Name = ssb.ToString();
                    redCircle.Fill = new SolidColorBrush(Colors.White);
                    redCircle.Margin = new Thickness(10, 3, 0, 3);
                    ar[j, i] = redCircle;
                    g.Children.Add(redCircle);
                }


                SideR.Children.Add(g);
            }
            TextBlock changeSize = new TextBlock();
            {
                changeSize.FontSize = 20;
                changeSize.Margin = new Thickness(0, 5, 0, 0);
                changeSize.Name = "txtBoardSize";
                changeSize.Text = "Change Board Size";
                top.Children.Add(changeSize);
                top.Width = b.Width;

            }
            StackPanel kk = new StackPanel();
            kk.Name = "inn";
            kk.Orientation = Orientation.Horizontal;
            TextBlock changeSizeCol = new TextBlock();
            {
                changeSizeCol.Margin = new Thickness(0, 10, 5, 0);
                changeSizeCol.Name = "txtBoardCol";
                changeSizeCol.Text = "Column";
                kk.Children.Add(changeSizeCol);
            }
            ComboBox column = new ComboBox();
            {
                column.Name = "columnBox";
                column.Height = 20;
                column.Loaded += columnLoaded;
                column.SelectionChanged += columnSelection;
                kk.Children.Add(column);
            }
            TextBlock changeSizeRow = new TextBlock();
            {
                changeSizeRow.Margin = new Thickness(10, 10, 5, 0);
                changeSizeRow.Name = "txtBoardRow";
                changeSizeRow.Text = "Row";
                kk.Children.Add(changeSizeRow);
            }
            ComboBox row = new ComboBox();
            {
                row.Name = "columnBox";
                row.Height = 20;
                row.Loaded += rowLoaded;
                row.SelectionChanged += rowSelection;
                kk.Children.Add(row);
            }
            Button btnn = new Button();
            {
                btnn.Name = "Btn" + "kk";
                btnn.Height = 20;
                btnn.Content = "Submit Change";
                btnn.Foreground = new SolidColorBrush(Colors.White);
                btnn.Margin = new Thickness(5, 5, 0, 2.5);
                btnn.Click += changeBoardSize; 
                kk.Children.Add(btnn);
            }
            top.Children.Add(kk);

            root.Height = rowSize * 60 + 50 + 95; //(rowSize + 1) * 10;
            root.Width = 150 + colSize * 60 + 55;//(colSize + 1) * 10;
            Canvas.Margin = new Thickness(15, 10, 15, 10);
            // Console.WriteLine(SideR.Width);
            StackPanel file = new StackPanel();
            file.Orientation = Orientation.Horizontal;
        }
        private void rowSelection(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            
           Row = Convert.ToInt32(comboBox.SelectedItem.ToString());
        }
        private void columnSelection(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            Column = Convert.ToInt32(comboBox.SelectedItem.ToString());


        }
        private void changeBoardSize(object sender, RoutedEventArgs e)
        {
           
            MainWindow m = new MainWindow(Column, Row);
            root.Close();
            board = null;
            board = new board_controller(Column, Row, "Red");
            m.ShowDialog();
           

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Uri b = new Uri(@"..\\black_pics\\black_001.png", UriKind.Relative);
            Button m = sender as Button;
            string columnName = m.Name;

            int columnInt = Convert.ToInt32(columnName.Substring(4));

            //  ImageBrush myBrush = new ImageBrush();
            // myBrush.ImageSource = new BitmapImage(b);
            int[] board_return = new int[5];
            //  
            board_return = board.makeMove(columnInt);
            if (board_return[3] != -1)
            {
                if (board_return[4] == 1)
                {
                    ar[board_return[2], board_return[3]].Fill = new SolidColorBrush(Colors.Red);
                    
                }
                else if (board_return[4] == 2)
                {
                    ar[board_return[2], board_return[3]].Fill = new SolidColorBrush(Colors.Black);
                }
            }
            // ar[0, 1].Fill =// myBrush;
            //
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
        private void columnLoaded(object sender, RoutedEventArgs e)
        {
            List<int> data = new List<int>();
            for (int i = 4; i < 21; i++)
            {
                data.Add(i);
            }
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedValue = Column;

        }
        private void rowLoaded(object sender, RoutedEventArgs e)
        {
            List<int> data = new List<int>();
            for (int i = 4; i < 16; i++)
            {
                data.Add(i);
            }
            var comboBox = sender as ComboBox;


            comboBox.ItemsSource = data;


            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;
            comboBox.SelectedValue = Row;

        }
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            // ... A List.
            List<string> data = new List<string>();
            data.Add("Computer");
            data.Add("Human");

            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            // ... Make the first item selected.
            //comboBox.SelectedIndex = 0;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            //var comboBox = sender as ComboBox;
            txtSelectTeam.Visibility = comboBox.SelectedItem == null ? Visibility.Visible : Visibility.Hidden;
            if(comboBox.SelectedItem == comboBox_color.SelectedItem && comboBox.SelectedItem.Equals("Computer"))
            {
                comboBox_time.Visibility = Visibility.Visible;
                txtSelectTime.Visibility = Visibility.Visible;
                comboBox_sim.Visibility = Visibility.Visible;
                txtSelectTime.Visibility = Visibility.Visible;
            }
            // ... Set SelectedItem as Window Title.
            string value = comboBox.SelectedItem as string;
            if (value == "Computer")
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
          //  this.Title = "Selected: " + value;

        }
        private void comboBox_color_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("Computer");
            data.Add("Human");

            // ... Get the ComboBox reference.
            var comboBox_color = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            comboBox_color.ItemsSource = data;

        }

        private void comboBox_color_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtSelectColor.Visibility = comboBox_color.SelectedItem == null ? Visibility.Visible : Visibility.Hidden;
            if (comboBox.SelectedItem == comboBox_color.SelectedItem && comboBox_color.SelectedItem.Equals("Computer"))
            {
                comboBox_time.Visibility = Visibility.Visible;
                txtSelectTime.Visibility = Visibility.Visible;
                comboBox_sim.Visibility = Visibility.Visible;
                txtSelectSim.Visibility = Visibility.Visible;
            }

        }

        private void player_move_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("Red");
            data.Add("Black");

            var comboBox_move = sender as ComboBox;

            comboBox_move.ItemsSource = data;
           


        }

        private void player_move_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtSelectP1.Visibility = player_move.SelectedItem == null ? Visibility.Visible : Visibility.Hidden;
            
        }

        private void comboBox_time_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("No Limit");
            for (int i = 1; i < 11; i++)
            {
                data.Add(i.ToString()+" sec");
            }
            
            var comboBox = sender as ComboBox;


            comboBox.ItemsSource = data;

        }

        private void comboBox_time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtSelectTime.Visibility = comboBox_time.SelectedItem == null ? Visibility.Visible : Visibility.Hidden;
        }

        private void comboBox_sim_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> data = new List<int>();
            for (int i = 1; i < 10 ; i++)
            {
                data.Add(i);
            }
            for (int i = 20; i < 101; i+=10)
            {
                data.Add(i);
            }

            var comboBox = sender as ComboBox;


            comboBox.ItemsSource = data;


        }

        private void comboBox_sim_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtSelectSim.Visibility = comboBox_sim.SelectedItem == null ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
