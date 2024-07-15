using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Ex02.ConsoleUtils;

namespace A24_Ex02_Eran_203606736_Matan_208389999
{
    enum PlayerSign
    {
        X,
        O
    }
    enum PlayerType
    {
        Human,
        Computer
    }
    class GameManager
    {
        private GameBoard m_GameBoard;
        private Player m_CurrentPlayer;
        private Player m_PlayerA = new Player(PlayerType.Human, "Player A", PlayerSign.O);
        private Player m_PlayerB;
        private short m_Round = 1;
        private readonly Logic r_Logic;
        private readonly UI r_UI;

        public GameManager(Logic i_Logic, UI i_UI)
        {
            this.r_Logic = i_Logic;
            this.r_UI = i_UI;
        }

        public void StartGame() {
            short rows = 0;
            short cols = 0;
            bool endGame = false;

            r_UI.WelcomeMessage();
            r_Logic.SetPlayerB(r_UI.GetUserInputSelectionPlayer(), ref m_PlayerB);
            r_UI.GetColsAndRowsFromUser(ref rows, ref cols);
            r_Logic.CreateGameBoard(ref m_GameBoard, rows, cols);
            r_UI.PrintBoard(m_GameBoard);
            m_CurrentPlayer = m_PlayerA;

            while (!endGame)
            {
                while (true)
                {
                    string columnChoice = "";
                    r_UI.PrintMessage($"Turn: {m_CurrentPlayer.Name}");
                    columnChoice = r_UI.GetPlayerColumnChoice(m_CurrentPlayer, m_GameBoard.Cols);
                    if (columnChoice.ToLower() == "q")
                    {
                        quiteGame();
                        r_UI.PrintTableScore(m_PlayerA, m_PlayerB);
                        if(r_UI.Rematch() == true)
                        {
                            initializeGame(rows, cols);
                        }
                        else
                        {
                            endGame = true;
                        }
                        break;
                    }
                    while (r_Logic.IsColumnInBoardRange(columnChoice, m_GameBoard.Cols) != true)
                    {
                        r_UI.PrintMessage($"Input Error!\nYou must choose column between {1} - {m_GameBoard.Cols}");
                        columnChoice = r_UI.GetPlayerColumnChoice(m_CurrentPlayer, m_GameBoard.Cols);
                    }
                    while (r_Logic.IsColumnFull(columnChoice, m_GameBoard) != false)
                    {
                        r_UI.PrintMessage("This column is full, please choose other one");
                        columnChoice = r_UI.GetPlayerColumnChoice(m_CurrentPlayer, m_GameBoard.Cols);
                    }
                    r_Logic.SetSelectionOnBoardColumn(columnChoice, ref m_GameBoard, m_CurrentPlayer);
                    Screen.Clear();

                    r_UI.PrintBoard(m_GameBoard);

                    if(m_Round >= 7)
                    {
                        if(r_Logic.CheckForWin(m_GameBoard) == true)
                        {
                            winner();

                            r_UI.PrintTableScore(m_PlayerA, m_PlayerB);

                            if(r_UI.Rematch() == true)
                            {
                                initializeGame(rows,cols);
                                break;
                            }
                            else
                            {
                                endGame = true;
                                break;
                            }
                        }
                    }
                    m_Round++;
                    if(r_Logic.IsGameDraw(m_Round, rows, cols) == true)
                    {
                        r_UI.PrintMessage("The game ended in DRAW!");
                        r_UI.PrintTableScore(m_PlayerA, m_PlayerB);
                        if(r_UI.Rematch() == true)
                        {
                            initializeGame(rows,cols);
                            break;
                        }
                    }
                    m_CurrentPlayer = r_Logic.ChangeTurn(m_CurrentPlayer, m_PlayerA, m_PlayerB);
                }
            }
            r_UI.PrintMessage("ByeBye");
            Thread.Sleep(3000);
        }

        private void initializeGame(short i_Rows, short i_Cols) {
            r_Logic.CreateGameBoard(ref m_GameBoard, i_Rows, i_Cols);
            r_UI.PrintBoard(m_GameBoard);
            m_CurrentPlayer = m_PlayerA;
            m_Round = 1;
            Screen.Clear();
            r_UI.PrintBoard(m_GameBoard);
        }

        private void winner()
        {
            r_UI.PrintMessage($"### {m_CurrentPlayer.Name} WINS! ###");
            r_Logic.UpdatePlayerScore(ref m_CurrentPlayer);
        }

        private void quiteGame()
        {
            r_UI.PrintMessage("You have quite the game");
            if(m_CurrentPlayer == m_PlayerA)
            {
                r_Logic.UpdatePlayerScore(ref m_PlayerB);
                r_UI.PrintMessage($"{m_PlayerB.Name} Wins!");
            }
            else
            {
                r_Logic.UpdatePlayerScore(ref m_PlayerA);
                r_UI.PrintMessage($"{m_PlayerA.Name} Wins!");
            }
        }
    }
}
