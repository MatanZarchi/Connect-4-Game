using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A24_Ex02_Eran_203606736_Matan_208389999
{
    // $G$ CSS-999 (-5) The Class must have an access modifier.
    class Logic
    {
        public Player ChangeTurn(Player i_CurrentPlayer, Player i_PlayerA, Player i_PlayerB)
        {
            i_CurrentPlayer = (i_CurrentPlayer == i_PlayerA) ? i_PlayerB : i_PlayerA;
            return i_CurrentPlayer;
        }

        public void CreateGameBoard(ref GameBoard i_GameBoard, short i_Rows, short i_Cols) 
        {
            i_GameBoard = new GameBoard(i_Rows, i_Cols);
            InitBoard(i_GameBoard);
        }
        // $G$ CSS-028 (-5) A method should not include more than one return statement.
        public bool IsColumnInBoardRange(string i_ColumnNumber, short i_BoardCols)
        {
            short parsedColumnNumber = short.Parse(i_ColumnNumber);
            if (parsedColumnNumber >= 1 && parsedColumnNumber <= i_BoardCols)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // $G$ CSS-999 (-3) Missing blank line between methods
        // $G$ CSS-028 (-5) A method should not include more than one return statement.
        public bool IsColumnFull(string i_ColumnNumber, GameBoard i_GameBoard)
        {
            short parsedColumnNumber = short.Parse(i_ColumnNumber);
            if (i_GameBoard.Board[0, parsedColumnNumber - 1] != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // $G$ CSS-999 (-3) Missing blank line between methods
        public void SetSelectionOnBoardColumn(string i_ColumnNumber,ref GameBoard i_GameBoard, Player i_CurrentPlayer)
        {
            short parsedColumnNumber = short.Parse(i_ColumnNumber);
            for (int i = i_GameBoard.Rows - 1; i >= 0; i--)
            {
                if (i_GameBoard.Board[i, parsedColumnNumber - 1] == -1)
                {
                    i_GameBoard.Board[i, parsedColumnNumber - 1] = (short)i_CurrentPlayer.Sign;
                    break;
                }
            }
        }
        // $G$ CSS-028 (-5) A method should not include more than one return statement.
        private bool CheckForHorizontalWin(GameBoard i_GameBoard)
        {
            for (int i = 0; i < i_GameBoard.Rows; i++)
            {
                for (int j = 0; j <= i_GameBoard.Cols - 4; j++)
                {
                    if (i_GameBoard.Board[i, j] != -1 &&
                        i_GameBoard.Board[i, j] == i_GameBoard.Board[i, j + 1] &&
                        i_GameBoard.Board[i, j] == i_GameBoard.Board[i, j + 2] &&
                        i_GameBoard.Board[i, j] == i_GameBoard.Board[i, j + 3])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckForVerticalWin(GameBoard i_GameBoard)
        {
            for (int i = 0; i <= i_GameBoard.Rows - 4; i++)
            {
                for (int j = 0; j < i_GameBoard.Cols; j++)
                {
                    if (i_GameBoard.Board[i, j] != -1 &&
                        i_GameBoard.Board[i, j] == i_GameBoard.Board[i + 1, j] &&
                        i_GameBoard.Board[i, j] == i_GameBoard.Board[i + 2, j] &&
                        i_GameBoard.Board[i, j] == i_GameBoard.Board[i + 3, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckForDiagonalWin(GameBoard i_GameBoard)
        {
            // Check for diagonal win (left to right)
            for (int i = 0; i <= i_GameBoard.Rows - 4; i++)
            {
                for (int j = 0; j <= i_GameBoard.Cols - 4; j++)
                {
                    if (i_GameBoard.Board[i, j] != -1 &&
                        i_GameBoard.Board[i, j] == i_GameBoard.Board[i + 1, j + 1] &&
                        i_GameBoard.Board[i, j] == i_GameBoard.Board[i + 2, j + 2] &&
                        i_GameBoard.Board[i, j] == i_GameBoard.Board[i + 3, j + 3])
                    {
                        return true;
                    }
                }
            }

            // Check for diagonal win (right to left)
            for (int i = 0; i <= i_GameBoard.Rows - 4; i++)
            {
                for (int j = 3; j < i_GameBoard.Cols; j++)
                {
                    if (i_GameBoard.Board[i, j] != -1 &&
                        i_GameBoard.Board[i, j] == i_GameBoard.Board[i + 1, j - 1] &&
                        i_GameBoard.Board[i, j] == i_GameBoard.Board[i + 2, j - 2] &&
                        i_GameBoard.Board[i, j] == i_GameBoard.Board[i + 3, j - 3])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CheckForWin(GameBoard i_GameBoard)
        {
            return CheckForHorizontalWin(i_GameBoard) || CheckForVerticalWin(i_GameBoard) || CheckForDiagonalWin(i_GameBoard);
        }

        private void InitBoard(GameBoard i_GameBoard)
        {
            for (int i = 0; i < i_GameBoard.Rows; i++)
            {
                for (int j = 0; j < i_GameBoard.Cols; j++)
                {
                    i_GameBoard.Board[i, j] = -1;
                }
            }
        }
        public void UpdatePlayerScore(ref Player i_CurrentPlayer) {
            i_CurrentPlayer.Score++;
        }
        // $G$ CSS-014 (-5) Bad variable name (should be in the form of o_CamelCase).
        public void SetPlayerB(PlayerType i_PlayerType, ref Player i_SetPlayerB)
        {
            if (i_PlayerType == PlayerType.Human)
            {
                i_SetPlayerB = new Player(PlayerType.Human, "Player B", PlayerSign.X);
            }
            else
            {
                i_SetPlayerB = new Player(PlayerType.Computer, "Player B", PlayerSign.X);
            }
        }
        // $G$ DSN-004 (-3) Redundant code why not return i_Round == i_Rows * i_Cols + 1
        public bool IsGameDraw(short i_Round, short i_Rows, short i_Cols)
        {
            if(i_Round == i_Rows * i_Cols + 1 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
