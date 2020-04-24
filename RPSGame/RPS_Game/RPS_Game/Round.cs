using System;
using System.Collections.Generic;
using System.Text;

namespace RPS_Game
{
    class Round
    {
        private Player winner;
        //private string p1Chosen;
       // private string p2chosen;
        public Player p1;
        public Player p2;
        private int rounds;

       public char MakeAChoice()
        { 
            //making sure that players input the right string
            char h;
            do
            {
                Console.WriteLine("Chose your hand : R for Rock, P for Paper and S for Scissor");
                h = char.ToUpper(Console.ReadLine()[0]);
            } while (!h.Equals("R") || !h.Equals("P") || !h.Equals("S"));
            
            return h;
        }
        //public string p1Choice { 
         //   get => p1Chosen;
           // set => p1Chosen = MakeAChoice();
           // }
        //public string p2Choice { get => p2chosen; set => p2Choice = MakeAChoice(); }
        public Player Winner { get => winner; }
        public Player rules()
        {
            
            if (p1Choice == p2Choice)
            {
                Console.WriteLine("We have a tie");
                winner = null;
                return winner;
            }
            else if ((p1Choice == "R" && p2Choice == "S") || (p1Choice == "S" && p2Choice == "P") || (p1Choice == "P" && p2Choice == "R"))
            {
                winner = 
                Console.WriteLine($"Player {player1.playerName} wins.");
            }
            else
            {
                player2.score++;
                Console.WriteLine($"Player {player2.playerName} wins.");
            }
            set => value; 
        }

       public Round(Player p1, Player p2)
        {
            rounds += 1;
            Console.WriteLine($"Round {rounds} | {p1.Name} VS {p2.Name}");
            p1.playerHand = MakeAChoice();

        }
    }


}
