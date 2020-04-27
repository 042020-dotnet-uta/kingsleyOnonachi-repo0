using System;
using System.Collections.Generic;
using System.Text;

namespace RPS_Game
{
    public class Round
    {
        private Player _winner;//store who won this round

        public string p1Choice { get; set; }
        public string p2Choice { get; set; }
        public Boolean pWinner = false;//false means player 1 won the round. True means player 2 won the round.
        public Player Winner { get => _winner; set => _winner = value; }
    }
}
