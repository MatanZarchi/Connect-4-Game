using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A24_Ex02_Eran_203606736_Matan_208389999
{
    
    class Player
    {
        private PlayerType m_PlayerType;
        private PlayerSign m_Sign;
        private string m_Name;
        private short m_Score;

        public Player(PlayerType i_PlayerType, string i_Name, PlayerSign i_PlayerSign)
        {
            this.m_PlayerType = i_PlayerType;
            this.m_Name = i_Name;
            this.m_Sign = i_PlayerSign;
        }

        public PlayerType TypePlayer
        {
            get { return m_PlayerType; }
            set { m_PlayerType = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public short Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }

        public PlayerSign Sign
        {
            get { return m_Sign; }
        }
    }
}
