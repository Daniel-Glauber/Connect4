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
using System.Threading;

namespace connect4
{
    public partial class MainWindow : Window
    {
        private static int Column = 7;
        private static int Row = 6;
        public Ellipse[,] ar;
        public Button[] but;
        public Boolean submit_buttons = false;
        bool computerHum = false;

        public Button[] submit_but = new Button[2];
        board_controller board;
        public string[] players = new string[8];
        public MainWindow()
        {
            InitializeComponent();

            CreateDynamicStackPanel(6, 7);
        }
        public void start_Sim()
        {
            if (players[1] != "Human" && players[4] != "Human")
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                if (board.next_playersTurn.ToString() == "Red")
                {
                    startInfo.FileName = players[1];
                    if (players[3] == "yes")
                    {
                        startInfo.ErrorDialog = false;
                        startInfo.WindowStyle = ProcessWindowStyle.Normal;
                        startInfo.CreateNoWindow = true;
                        using (Process b = Process.Start(startInfo))
                        {
                            if (players[2] != "No Limit")
                            {
                                players[2] = players[2].Replace(" sec", "");
                                if (!b.WaitForExit(Convert.ToInt32(players[2]) * 1000))
                                {

                                    b.Kill();
                                    textBlock_loss.Text = "Red Took Too Long";
                                    textBlock_loss.Visibility = Visibility.Visible;

                                    foreach (Button btn in but)
                                    {
                                        btn.IsHitTestVisible = false;
                                    }

                                }
                            }

                        }

                    }
                    else
                    {
                        startInfo.ErrorDialog = false;
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.CreateNoWindow = true;
                        using (Process b = Process.Start(startInfo))
                        {
                            if (players[2] != "No Limit")
                            {
                                players[2] = players[2].Replace(" sec", "");

                                if (!b.WaitForExit(Convert.ToInt32(players[2]) * 1000))
                                {

                                    b.Kill();
                                    textBlock_loss.Text = "Red Took Too Long";
                                    textBlock_loss.Visibility = Visibility.Visible;

                                    foreach (Button btn in but)
                                    {
                                        btn.IsHitTestVisible = false;
                                    }

                                }
                            }
                        }

                    }
                }
                else if (board.next_playersTurn.ToString() == "Black")
                {
                    startInfo.FileName = players[4];
                    if (players[6] == "yes")
                    {
                        startInfo.ErrorDialog = false;
                        startInfo.WindowStyle = ProcessWindowStyle.Normal;
                        startInfo.CreateNoWindow = true;
                        using (Process b = Process.Start(startInfo))
                        {
                            if (players[5] != "No Limit")
                            {
                                players[5] = players[5].Replace(" sec", "");
                                if (!b.WaitForExit(Convert.ToInt32(players[5]) * 1000))
                                {

                                    b.Kill();
                                    textBlock_loss.Text = "Black Took Too Long";
                                    textBlock_loss.Visibility = Visibility.Visible;

                                    foreach (Button btn in but)
                                    {
                                        btn.IsHitTestVisible = false;
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        startInfo.ErrorDialog = false;
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.CreateNoWindow = true;
                        using (Process b = Process.Start(startInfo))
                        {
                            if (players[5] != "No Limit")
                            {
                                players[5] = players[5].Replace(" sec", "");
                                if (!b.WaitForExit(Convert.ToInt32(players[5]) * 1000))
                                {

                                    b.Kill();
                                    textBlock_loss.Text = "Black Took Too Long";
                                    textBlock_loss.Visibility = Visibility.Visible;

                                    foreach (Button btn in but)
                                    {
                                        btn.IsHitTestVisible = false;
                                    }

                                }
                            }
                        }
                    }

                }

            }
            if (players[1] == "Human" && players[4] != "Human")
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                if (board.next_playersTurn.ToString() == "Black")
                {
                    startInfo.FileName = players[4];
                    if (players[6] == "yes")
                    {
                        startInfo.ErrorDialog = false;
                        startInfo.WindowStyle = ProcessWindowStyle.Normal;
                        startInfo.CreateNoWindow = true;
                        using (Process b = Process.Start(startInfo))
                        {
                            if (players[5] != "No Limit")
                            {
                                players[5] = players[5].Replace(" sec", "");
                                if (!b.WaitForExit(Convert.ToInt32(players[5]) * 1000))
                                {

                                    b.Kill();
                                    textBlock_loss.Text = "Black Took Too Long";
                                    textBlock_loss.Visibility = Visibility.Visible;

                                    foreach (Button btn in but)
                                    {
                                        btn.IsHitTestVisible = false;
                                    }

                                }
                            }
                        }

                    }
                    else
                    {
                        startInfo.ErrorDialog = false;
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.CreateNoWindow = true;
                        using (Process b = Process.Start(startInfo))
                        {
                            if (players[5] != "No Limit")
                            {
                                players[5] = players[5].Replace(" sec", "");
                                if (!b.WaitForExit(Convert.ToInt32(players[5]) * 1000))
                                {

                                    b.Kill();
                                    textBlock_loss.Text = "Black Took Too Long";
                                    textBlock_loss.Visibility = Visibility.Visible;

                                    foreach (Button btn in but)
                                    {
                                        btn.IsHitTestVisible = false;
                                    }

                                }
                            }
                        }
                    }

                }

            }
            if (players[1] != "Human" && players[4] == "Human")
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                if (board.next_playersTurn.ToString() == "Red")
                {
                    startInfo.FileName = players[1];
                    if (players[3] == "yes")
                    {
                        startInfo.ErrorDialog = false;
                        startInfo.WindowStyle = ProcessWindowStyle.Normal;
                        startInfo.CreateNoWindow = true;
                        using (Process b = Process.Start(startInfo))
                        {
                            if (players[2] != "No Limit")
                            {
                                players[2] = players[2].Replace(" sec", "");
                                if (!b.WaitForExit(Convert.ToInt32(players[2]) * 1000))
                                {

                                    b.Kill();
                                    textBlock_loss.Text = "Red Took Too Long";
                                    textBlock_loss.Visibility = Visibility.Visible;

                                    foreach (Button btn in but)
                                    {
                                        btn.IsHitTestVisible = false;
                                    }

                                }
                            }
                        }

                    }
                    else
                    {
                        startInfo.ErrorDialog = false;
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.CreateNoWindow = true;
                        using (Process b = Process.Start(startInfo))
                        {
                            if (players[2] != "No Limit")
                            {
                                players[2] = players[2].Replace(" sec", "");
                                if (!b.WaitForExit(Convert.ToInt32(players[2]) * 1000))
                                {

                                    b.Kill();
                                    textBlock_loss.Text = "Red Took Too Long";
                                    textBlock_loss.Visibility = Visibility.Visible;

                                    foreach (Button btn in but)
                                    {
                                        btn.IsHitTestVisible = false;
                                    }

                                }
                            }



                        }
                    }
                }
            }
        }

        public MainWindow(int col, int row)
        {
            Column = col;
            Row = row;

            InitializeComponent();

            CreateDynamicStackPanel(row, col);
        }
        private void create_buttons()
        {
            StackPanel g = new StackPanel();
            g.VerticalAlignment = VerticalAlignment.Bottom;
            //g.VerticalOffset = 10;
            g.Orientation = Orientation.Horizontal;
            Button start = new Button();
            {
                start.Name = "Start";
                start.Height = 20;
                start.Content = "Start";
                start.Foreground = new SolidColorBrush(Colors.Black);
                start.Margin = new Thickness(5, 5, 0, 2.5);
                start.Click += sumbit_Click;
            }
            submit_but[0] = start;
            g.Children.Add(start);
            Button stop = new Button();
            {
                stop.Name = "Stop";
                stop.Height = 20;
                stop.Content = "Stop";
                stop.Foreground = new SolidColorBrush(Colors.Black);
                stop.Margin = new Thickness(5, 5, 0, 2.5);
                stop.Click += sumbit_Click;
            }
            submit_but[1] = stop;
            g.Children.Add(stop);
            if (!submit_buttons)
            {
                SideL.Children.Add(g);
                submit_buttons = true;
            }
        }
        private void sumbit_Click(object sender, RoutedEventArgs e)
        {
            Button m = sender as Button;
            string name = m.Name;

            if (name == "Stop")
            {
                submit_but[0].IsHitTestVisible = true;
                m.IsHitTestVisible = false;
                foreach (Button btn in but)
                {
                    btn.IsHitTestVisible = false;
                }

                textBlock_loss.Visibility = Visibility.Hidden;
                foreach (Ellipse var in ar)
                {
                    var.Fill = new SolidColorBrush(Colors.White);
                }
                red_comboBox.IsHitTestVisible = true;
                black_comboBox.IsHitTestVisible = true;
                player_move.IsHitTestVisible = true;

                if (red_comboBox.SelectedItem == black_comboBox.SelectedItem && red_comboBox.SelectedItem.Equals("Computer") && comboBox_sim.SelectedItem != null && comboBox_red_time.SelectedItem != null && comboBox_black_time.SelectedItem != null)
                {
                    red_comboBox.IsHitTestVisible = true;
                    black_comboBox.IsHitTestVisible = true;
                    player_move.IsHitTestVisible = true;
                    RedCheckBox.IsHitTestVisible = true;
                    BlackCheckBox.IsHitTestVisible = true;
                    comboBox_black_time.IsHitTestVisible = true;
                    comboBox_red_time.IsHitTestVisible = true;
                    comboBox_sim.IsHitTestVisible = true;


                }
            }
            else if (name == "Start")
            {
                submit_but[1].IsHitTestVisible = true;
                m.IsHitTestVisible = false;


                if (red_comboBox.SelectedItem == black_comboBox.SelectedItem && red_comboBox.SelectedItem.Equals("Computer") && comboBox_sim.SelectedItem != null && comboBox_red_time.SelectedItem != null && comboBox_black_time.SelectedItem != null)
                {
                    red_comboBox.IsHitTestVisible = false;
                    black_comboBox.IsHitTestVisible = false;
                    player_move.IsHitTestVisible = false;
                    RedCheckBox.IsHitTestVisible = false;
                    BlackCheckBox.IsHitTestVisible = false;
                    comboBox_black_time.IsHitTestVisible = false;
                    comboBox_red_time.IsHitTestVisible = false;
                    comboBox_sim.IsHitTestVisible = false;
                    board = new board_controller(Row, Column, players);
                    while (two_computer()) {; }




                }

                if (red_comboBox.SelectedItem != black_comboBox.SelectedItem && black_comboBox.SelectedItem != null && red_comboBox.SelectedItem.Equals("Computer"))
                {
                    AutoResetEvent arEvent = new AutoResetEvent(false);
                    red_comboBox.IsHitTestVisible = false;
                    black_comboBox.IsHitTestVisible = false;
                    player_move.IsHitTestVisible = false;
                    RedCheckBox.IsHitTestVisible = false;
                    comboBox_red_time.IsHitTestVisible = false;
                    board = new board_controller(Row, Column, players);
                    if (players[0] == "Red")
                    {
                        computerHum = true;

                        two_computer();

                        foreach (Button btn in but)
                        {
                            btn.IsHitTestVisible = true;
                        }
                    }
                    else if (players[0] == "Black")
                    {
                        computerHum = true;

                        foreach (Button btn in but)
                        {
                            btn.IsHitTestVisible = true;
                        }

                    }
                }
                if (red_comboBox.SelectedItem != black_comboBox.SelectedItem && black_comboBox.SelectedItem != null && red_comboBox.SelectedItem.Equals("Human"))
                {
                    red_comboBox.IsHitTestVisible = false;
                    black_comboBox.IsHitTestVisible = false;
                    player_move.IsHitTestVisible = false;
                    BlackCheckBox.IsHitTestVisible = false;
                    comboBox_black_time.IsHitTestVisible = false;
                    comboBox_sim.IsHitTestVisible = false;
                    board = new board_controller(Row, Column, players);
                    if (players[0] == "Black")
                    {
                        computerHum = true;
                        two_computer();
                        foreach (Button btn in but)
                        {
                            btn.IsHitTestVisible = true;
                        }

                    }
                    else if (players[0] == "Red")
                    {
                        computerHum = true;

                        foreach (Button btn in but)
                        {
                            btn.IsHitTestVisible = true;
                        }

                    }
                }
                if (red_comboBox.SelectedItem == black_comboBox.SelectedItem && black_comboBox.SelectedItem != null && red_comboBox.SelectedItem.Equals("Human"))
                {
                    foreach (Button btn in but)
                    {
                        btn.IsHitTestVisible = true;
                    }
                    red_comboBox.IsHitTestVisible = false;
                    black_comboBox.IsHitTestVisible = false;
                    player_move.IsHitTestVisible = false;
                    board = new board_controller(Row, Column, players);


                }
                m.IsHitTestVisible = false;
                red_comboBox.IsHitTestVisible = false;
                black_comboBox.IsHitTestVisible = false;
                player_move.IsHitTestVisible = false;
            }

        }
        private void CreateDynamicStackPanel(int rowSize, int colSize)
        {
            ar = new Ellipse[colSize, rowSize];
            System.Windows.Shapes.Rectangle b = new System.Windows.Shapes.Rectangle();

            b.Width = (colSize * 50 + (colSize + 1) * 10);
            b.Height = (rowSize * 50 + (rowSize + 1) * 6) + 25;
            b.Fill = new SolidColorBrush(Colors.Yellow);
            Board.Children.Add(b);
            but = new Button[colSize];
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
                    btn.IsHitTestVisible = false;
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
                    but[j] = btn;
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
                btnn.Foreground = new SolidColorBrush(Colors.Black);
                btnn.Margin = new Thickness(5, 5, 0, 2.5);
                btnn.Click += changeBoardSize;
                kk.Children.Add(btnn);
            }
            top.Children.Add(kk);

            root.Height = rowSize * 60 + 50 + 95;
            root.Width = 150 + colSize * 60 + 55;
            Canvas.Margin = new Thickness(15, 10, 15, 10);
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
            players[0] = "Red";
            board = new board_controller(Column, Row, players);
            m.ShowDialog();


        }
        public bool two_computer()
        {


            start_Sim();

            int col = board.get_move();

            int[] board_return = new int[5];
            Array.Copy(board.makeMove(col), 0, board_return, 0, 5);
            display_move(board_return);
            return board.can_continue(board_return);
        }
        public void display_move(int[] board_return)
        {
            if (board_return[3] == -1)
            {
                if (board_return[4] == 1)
                {
                    textBlock_loss.Text = "Red Made Bad Move";
                    textBlock_loss.Visibility = Visibility.Visible;
                    foreach (Button btn in but)
                    {
                        btn.IsHitTestVisible = false;
                    }

                }
                else if (board_return[4] == 2)
                {
                    textBlock_loss.Text = "Black Made Bad Move";
                    textBlock_loss.Visibility = Visibility.Visible;
                    foreach (Button btn in but)
                    {
                        btn.IsHitTestVisible = false;
                    }
                }
            }
            else if (board_return[1] == -2)
            {
                if (board_return[4] == 1)
                {
                    ar[board_return[2], board_return[3]].Fill = new SolidColorBrush(Colors.Red);

                    textBlock_loss.Text = "Red Won";
                    textBlock_loss.Visibility = Visibility.Visible;
                    foreach (Button btn in but)
                    {
                        btn.IsHitTestVisible = false;
                    }

                }
                else if (board_return[4] == 2)
                {
                    ar[board_return[2], board_return[3]].Fill = new SolidColorBrush(Colors.Black);
                    textBlock_loss.Text = "Black Won";
                    textBlock_loss.Visibility = Visibility.Visible;
                }
                foreach (Button btn in but)
                {
                    btn.IsHitTestVisible = false;
                }
            }
            else {
                if (board_return[4] == 1)
                {
                    ar[board_return[2], board_return[3]].Fill = new SolidColorBrush(Colors.Red);

                }
                else if (board_return[4] == 2)
                {
                    ar[board_return[2], board_return[3]].Fill = new SolidColorBrush(Colors.Black);
                }
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button m = sender as Button;
            string columnName = m.Name;

            int columnInt = Convert.ToInt32(columnName.Substring(4));


            int[] board_return = new int[5];
            board_return = board.makeMove(columnInt);
            display_move(board_return);
            if (computerHum)
            {
                two_computer();
            }

        }

        private void filePath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Select Computer Player";
            fDialog.Filter = "Exe Files|*.exe";
            bool? userClickedOK = fDialog.ShowDialog();
            if (userClickedOK == true)
            {
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
        private void red_comboBox_Loaded(object sender, RoutedEventArgs e)
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

        private void red_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (player_move.SelectedItem != null && red_comboBox.SelectedItem != black_comboBox.SelectedItem && black_comboBox.SelectedItem != null && red_comboBox.SelectedItem.Equals("Computer"))
            {
                create_buttons();
            }
            if (comboBox_sim.SelectedItem != null && comboBox_red_time.SelectedItem != null && player_move.SelectedItem != null && red_comboBox.SelectedItem == black_comboBox.SelectedItem && black_comboBox.SelectedItem != null && red_comboBox.SelectedItem.Equals("Computer"))
            {
                create_buttons();
            }
            if (player_move.SelectedItem != null && red_comboBox.SelectedItem != black_comboBox.SelectedItem && black_comboBox.SelectedItem != null && red_comboBox.SelectedItem.Equals("Human"))
            {
                create_buttons();
            }
            if (player_move.SelectedItem != null && red_comboBox.SelectedItem == black_comboBox.SelectedItem && black_comboBox.SelectedItem != null && red_comboBox.SelectedItem.Equals("Human"))
            {
                create_buttons();
            }
            txtRedPlayer.Visibility = red_comboBox.SelectedItem == null ? Visibility.Visible : Visibility.Hidden;
            redLabel.Visibility = red_comboBox.SelectedItem != null ? Visibility.Visible : Visibility.Collapsed;
            txtRedTime.Visibility = comboBox_red_time.SelectedItem == null ? Visibility.Visible : Visibility.Hidden;
            if (player_move.SelectedItem != null && red_comboBox.SelectedItem == black_comboBox.SelectedItem && red_comboBox.SelectedItem.Equals("Computer"))
            {
                comboBox_red_time.Visibility = Visibility.Visible;
                txtRedTime.Visibility = Visibility.Visible;
                comboBox_sim.Visibility = Visibility.Visible;
                txtSelectSim.Visibility = Visibility.Visible;

            }
            string value = red_comboBox.SelectedItem as string;
            if (value == "Human")
            {
                comboBox_red_time.SelectedItem = null;
                comboBox_sim.SelectedItem = null;
                if (player_move.SelectedItem.Equals("Red"))
                {
                    players[0] = "Red";
                    players[1] = "Human";

                }
                else if (player_move.SelectedItem.Equals("Black"))
                {
                    players[0] = "Black";
                    players[1] = "Human";

                }
                RedCheckBox.Visibility = Visibility.Collapsed;
                comboBox_red_time.Visibility = Visibility.Collapsed;
                txtRedTime.Visibility = Visibility.Collapsed;
                comboBox_sim.Visibility = Visibility.Collapsed;
                txtSelectSim.Visibility = Visibility.Collapsed;
                redTimeLabel.Visibility = Visibility.Collapsed;
                simLabel.Visibility = Visibility.Collapsed;

            }
            if (value == "Computer")
            {
                redTimeLabel.Visibility = Visibility.Collapsed;
                simLabel.Visibility = Visibility.Collapsed;
                comboBox_red_time.Visibility = Visibility.Visible;
                RedCheckBox.Visibility = Visibility.Visible;
                OpenFileDialog fDialog = new OpenFileDialog();
                fDialog.Title = "Select Computer Player";
                fDialog.Filter = "Exe Files|*.exe";
                bool? userClickedOK = fDialog.ShowDialog();
                if (userClickedOK == true)
                {
                    if (player_move.SelectedItem.Equals("Red"))
                    {
                        players[0] = "Red";
                        players[1] = fDialog.FileName.ToString();

                    }
                    else if (player_move.SelectedItem.Equals("Black"))
                    {
                        players[0] = "Black";
                        players[1] = fDialog.FileName.ToString();

                    }
                }
            }

        }
        private void black_comboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("Computer");
            data.Add("Human");

            // ... Get the ComboBox reference.
            var comboBox_color = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            comboBox_color.ItemsSource = data;

        }

        private void black_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (player_move.SelectedItem != null && red_comboBox.SelectedItem != black_comboBox.SelectedItem && red_comboBox.SelectedItem != null && black_comboBox.SelectedItem.Equals("Computer"))
            {
                create_buttons();
            }

            if (player_move.SelectedItem != null && red_comboBox.SelectedItem != black_comboBox.SelectedItem && red_comboBox.SelectedItem != null && black_comboBox.SelectedItem.Equals("Human"))
            {
                create_buttons();
            }
            if (player_move.SelectedItem != null && red_comboBox.SelectedItem == black_comboBox.SelectedItem && red_comboBox.SelectedItem != null && black_comboBox.SelectedItem.Equals("Human"))
            {
                create_buttons();
            }
            txtBlackPlayer.Visibility = black_comboBox.SelectedItem == null ? Visibility.Visible : Visibility.Hidden;
            blackLabel.Visibility = black_comboBox.SelectedItem != null ? Visibility.Visible : Visibility.Collapsed;
            blackTimeLabel.Visibility = comboBox_black_time.SelectedItem != null ? Visibility.Visible : Visibility.Collapsed;
            txtBlackTime.Visibility = comboBox_black_time.SelectedItem == null ? Visibility.Visible : Visibility.Hidden;
            if (player_move.SelectedItem != null && red_comboBox.SelectedItem == black_comboBox.SelectedItem && black_comboBox.SelectedItem.Equals("Computer"))
            {

                comboBox_black_time.Visibility = Visibility.Visible;
                txtBlackTime.Visibility = Visibility.Visible;
                comboBox_sim.Visibility = Visibility.Visible;
                txtSelectSim.Visibility = Visibility.Visible;
            }
            string value = black_comboBox.SelectedItem as string;
            if (value == "Human")
            {
                comboBox_black_time.SelectedItem = null;
                comboBox_sim.SelectedItem = null;
                if (player_move.SelectedItem.Equals("Red"))
                {
                    players[0] = "Red";
                    players[4] = "Human";

                }
                else if (player_move.SelectedItem.Equals("Black"))
                {
                    players[0] = "Black";
                    players[4] = "Human";

                }
                BlackCheckBox.Visibility = Visibility.Collapsed;
                comboBox_black_time.Visibility = Visibility.Collapsed;
                txtBlackTime.Visibility = Visibility.Collapsed;
                comboBox_sim.Visibility = Visibility.Collapsed;
                txtSelectSim.Visibility = Visibility.Collapsed;
                blackTimeLabel.Visibility = Visibility.Collapsed;
                simLabel.Visibility = Visibility.Collapsed;

            }
            if (value == "Computer")
            {
                comboBox_black_time.Visibility = Visibility.Visible;
                txtBlackTime.Visibility = Visibility.Visible;
                blackTimeLabel.Visibility = Visibility.Collapsed;
                simLabel.Visibility = Visibility.Collapsed;
                BlackCheckBox.Visibility = Visibility.Visible;
                OpenFileDialog fDialog = new OpenFileDialog();
                fDialog.Title = "Select Computer Player";
                fDialog.Filter = "Exe Files|*.exe";
                bool? userClickedOK = fDialog.ShowDialog();
                if (userClickedOK == true)
                {
                    if (player_move.SelectedItem.Equals("Red"))
                    {
                        players[0] = "Red";
                        players[4] = fDialog.FileName.ToString();

                    }
                    else if (player_move.SelectedItem.Equals("Black"))
                    {
                        players[0] = "Black";
                        players[4] = fDialog.FileName.ToString();

                    }
                }

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
            players[0] = player_move.SelectedItem.ToString();
            txtSelectP1.Visibility = player_move.SelectedItem == null ? Visibility.Visible : Visibility.Hidden;
            colorLabel.Visibility = player_move.SelectedItem != null ? Visibility.Visible : Visibility.Collapsed;
            if (player_move.SelectedItem != null && red_comboBox.SelectedItem != null && red_comboBox.SelectedItem == black_comboBox.SelectedItem && red_comboBox.SelectedItem.Equals("Computer"))
            {
                comboBox_red_time.Visibility = Visibility.Visible;
                comboBox_black_time.Visibility = Visibility.Visible;
                txtRedTime.Visibility = Visibility.Visible;
                txtBlackTime.Visibility = Visibility.Visible;
                comboBox_sim.Visibility = Visibility.Visible;
                txtSelectSim.Visibility = Visibility.Visible;


            }


        }

        private void comboBox_time_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("No Limit");
            for (int i = 1; i < 11; i++)
            {
                data.Add(i.ToString() + " sec");
            }

            var comboBox = sender as ComboBox;


            comboBox.ItemsSource = data;

        }

        private void comboBox_time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox b = sender as ComboBox;
            if (b.Name == "comboBox_black_time")
            {
                players[5] = comboBox_black_time.SelectedItem.ToString();
                txtBlackTime.Visibility = comboBox_black_time.SelectedItem == null ? Visibility.Visible : Visibility.Collapsed;
                blackTimeLabel.Visibility = comboBox_black_time.SelectedItem != null ? Visibility.Visible : Visibility.Collapsed;

            }
            if (b.Name == "comboBox_red_time")
            {
                players[2] = comboBox_red_time.SelectedItem.ToString();
                txtRedTime.Visibility = comboBox_red_time.SelectedItem == null ? Visibility.Visible : Visibility.Collapsed;
                redTimeLabel.Visibility = comboBox_red_time.SelectedItem != null ? Visibility.Visible : Visibility.Collapsed;

            }

            // players[2] = comboBox_time.SelectedItem as string;
            if (comboBox_sim.SelectedItem != null && (comboBox_black_time.SelectedItem != null || comboBox_red_time.SelectedItem != null))
            {
                create_buttons();
            }
        }

        private void comboBox_sim_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> data = new List<int>();
            for (int i = 1; i < 10; i++)
            {
                data.Add(i);
            }
            for (int i = 20; i < 101; i += 10)
            {
                data.Add(i);
            }

            var comboBox = sender as ComboBox;


            comboBox.ItemsSource = data;


        }

        private void comboBox_sim_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtSelectSim.Visibility = comboBox_sim.SelectedItem == null ? Visibility.Visible : Visibility.Hidden;
            simLabel.Visibility = comboBox_sim.SelectedItem != null ? Visibility.Visible : Visibility.Collapsed;
            players[7] = comboBox_sim.SelectedItem.ToString();
            if (comboBox_sim.SelectedItem != null && (comboBox_black_time.SelectedItem != null || comboBox_red_time.SelectedItem != null))
            {
                create_buttons();
            }
        }

        private void RedCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            players[3] = "yes";

        }

        private void RedCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            players[3] = "no";
        }

        private void BlackCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            players[6] = "yes";
        }

        private void BlackCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            players[6] = "no";
        }
    }
}
