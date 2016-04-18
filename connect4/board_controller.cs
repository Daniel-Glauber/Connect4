using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace connect4
{
    class board_controller
    {
        private int numberOFrows, numberOFcolumns;
        private int[,] board;
       public enum Player
        {
            Red = 1, Black,
        }
        private Player next_playersTurn;
       
        public board_controller(int row, int col, string turn)
        {
            next_playersTurn =  (Player)Enum.Parse(typeof (Player), turn);
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
            if (Can_place_puck(column))
            {
                move[0] = numberOFcolumns;
                move[1] = numberOFrows;
                move[2] = column;
                move[3] = -1;
                move[4] = (int)next_playersTurn;
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
                board[column, move[3]] = (int)next_playersTurn;
                int m = (int)next_playersTurn % 2 + 1;
                next_playersTurn = (Player)m;
            }
            return move;
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
