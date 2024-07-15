using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A24_Ex02_Eran_203606736_Matan_208389999
{
    class GameBoard
    {
        private short m_Rows;
        private short m_Cols;
        private short[,] m_Board;
        
        public GameBoard(short i_Rows, short i_Cols)
        {
            this.m_Rows = i_Rows;
            this.m_Cols = i_Cols;
            InitBoard();
        }
        public short Rows
        {
            get { return m_Rows; }
            set { m_Rows = value; }
        }
        public short Cols
        {
            get { return m_Cols; }
            set { m_Cols = value; }
        }

        public short[,] Board
        {
            get { return m_Board; }
            set { m_Board = value; }
        }

        private void InitBoard()
        {
            m_Board = new short[m_Rows, m_Cols];
            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Cols; j++)
                {
                   m_Board[i, j] = -1;
                }
            }
        }
    }
}
