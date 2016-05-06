using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace connect4
{
    class board_controller
    {
        class Point
        {
            public readonly int X;
            public readonly int Y;
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
        private int numberOFrows, numberOFcolumns;
        private int[,] board;
        private string[] players = new string [8];
        private List<Point> redPucks;
        private List<Point> blackPucks;

        public enum Player
        {
            Red = 1, Black,
        }
        public Player next_playersTurn;

        public int get_move()
        {
            var reader = new StreamReader(File.OpenRead("move.txt"));       
            char n = (char)reader.Read();
            reader.Close();
            return n-'0';
        }
        
        public board_controller(int row, int col, string[] play)
        {
            for (int i = 0; i < 8; i++)
            {
                players[i] = play[i];
            }
            redPucks = new List<Point>();
            blackPucks = new List<Point>();

            next_playersTurn =  (Player)Enum.Parse(typeof (Player), players[0]);
            using (StreamWriter file = new StreamWriter("size.txt"))
            {
                file.Write(col.ToString() + " " + row.ToString() + " " + next_playersTurn.ToString());
                file.Close();
            }
            board = new int[col, row];
            numberOFcolumns = col;
            numberOFrows = row;
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    board[i, j] = 0;
                }
            }
            using (StreamWriter file = new StreamWriter("board.txt"))
            {
                for (int j = 0; j < numberOFrows; j++)
                {
                    for (int i = 0; i < numberOFcolumns; i++)
                    {



                        file.Write((board[i, j]));
                    }
                    file.WriteLine("\n");
                }
                file.Close();
            }
        }

       

        public Boolean Can_place_puck(int column)
        {
            if (board[column, 0] == 0)
            {
                return true;
            }
            else
                return false;
        }
        public int[] makeMove(int column)
        {
            int[] move = new int[5];
            
                move[0] = numberOFcolumns;
                move[1] = numberOFrows;
                move[2] = column;
                move[3] = -1;
                move[4] = (int)next_playersTurn;
            if (Can_place_puck(column))
            {
                for (int i = 0; i < numberOFrows; i++)
                {
                    if (board[column, i] == 0)
                    {
                        move[3] = i;
                    }
                    else
                        break;
                }
            }
            if (move[3] != -1)
            {
                Point puck = new Point(column, move[3]);
                int index = (int)next_playersTurn-1;
                if (index == 0)
                {
                    redPucks.Add(puck);
                }
                else
                {
                    blackPucks.Add(puck);
                }
                board[column, move[3]] = (int)next_playersTurn;
                using (StreamWriter file = new StreamWriter("board.txt"))
                {
                    for (int j = 0; j < numberOFrows; j++)
                    {
                        for (int i = 0; i < numberOFcolumns; i++)
                        {



                            file.Write((board[i, j]));
                        }
                        file.WriteLine("\n");
                    }
                    file.Close();
                }
                if (index == 0)
                {
                    if (-1 != checkforwin(redPucks, next_playersTurn))
                    {
                        move[1] = -2;
                    }
                }
                else
                {
                    if (-1 != checkforwin(blackPucks, next_playersTurn))
                    {
                            move[1] = -2;
                    }
                }
               
                int m = (int)next_playersTurn % 2 + 1;
                next_playersTurn = (Player)m;
            }
            return move;
        }
        private int checkforwin(List<Point> list, Player color)
        {

            foreach (var item in list)
            {
                int row = item.Y;
                int col = item.X;
                Boolean[] skips = new Boolean[8];
                for (int i = 0; i < 8; i++)
                {
                    skips[i] = true;
                }
                for (int i = 0; i < 4; i++)
                {
                    int colPlus = col + i;
                    int rowPlus = row + i;
                    int colMinus = col - i;
                    int rowMinus = row - i;

                    if (colPlus < numberOFcolumns)
                    {
                        if (rowPlus < numberOFrows)
                        {
                            if (skips[0] && board[colPlus, rowPlus] == (int)color)
                            {
                                if (i == 3)
                                    return list.IndexOf(item);
                            }
                            else
                                skips[0] = false;
                        }
                        if (rowMinus > 0)
                        {
                            if (skips[1] && board[colPlus, rowMinus] == (int)color)
                            {
                                if (i == 3)
                                    return list.IndexOf(item);

                            }
                            else
                                skips[1] = false;
                        }
                        if (skips[2] && board[colPlus, row] == (int)color)
                        {
                            if (i == 3)
                                return list.IndexOf(item);

                        }
                        else
                            skips[2] = false;
                    }
                    if (colMinus > 0)
                    {
                        if (rowMinus > 0)
                        {
                            if (skips[3] && board[colMinus, rowMinus] == (int)color)
                            {
                                if (i == 3)
                                    return list.IndexOf(item);
                            }
                            else
                                skips[3] = false;
                        }

                        if (skips[4] && board[colMinus, row] == (int)color)
                        {
                            if (i == 3)
                                return list.IndexOf(item);
                        }
                        else
                            skips[4] = false;
                    }
                    if (rowMinus > 0)
                    {
                        if (skips[5] && board[col, rowMinus] == (int)color)
                        {
                            if (i == 3)
                                return list.IndexOf(item);

                        }
                        else
                            skips[5] = false;
                    }
                    if (rowPlus < numberOFrows)
                    {
                        if (colMinus > 0)
                        {
                            if (skips[6] && board[colMinus, rowPlus] == (int)color)
                            {
                                if (i == 3)
                                    return list.IndexOf(item);

                            }
                            else
                                skips[6] = false;
                        }

                            if (skips[7] && board[col, rowPlus] == (int)color)
                            {
                            if (i == 3)
                                return list.IndexOf(item);

                        }
                        else
                            skips[7] = false;
                    }


                }
            }
            return -1;
        }
        public bool can_continue(int[] board)
        {
            if (board[3] == -1 || board[1] == -2)
            {
                return false;
            }
            else
                return true;
        }
        public int[,] getBoard
        {
            get
            {
                return board;
            }
        }

        public static T GetFromAttribute<T>(string attributeName)
        {
            Type type = typeof(T);
            return (T)Enum.Parse(typeof(T), type.GetRuntimeFields().FirstOrDefault(
              x => (x.CustomAttributes.Count() > 0 && (x.CustomAttributes.FirstOrDefault().ConstructorArguments.FirstOrDefault().Value as string).Equals(attributeName))).Name);
        }

    }
}
