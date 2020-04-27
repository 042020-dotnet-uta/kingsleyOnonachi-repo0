using System;
using System.Collections.Generic;
using System.Text;

namespace RPS_Game
{
    class Game
    {
        public List<Round> Rounds = new List<Round>();

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Player Winner { get; set; }

        public Game()
        {

        }
        public Game(Player p1, Player p2)
        {
            this.Player1 = p1;
            this.Player2 = p2;
        }

        
    }

}
