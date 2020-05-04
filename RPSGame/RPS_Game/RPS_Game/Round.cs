using System;
using System.Collections.Generic;
using System.Text;


namespace RPS_Game
{
    class Round
    {
        private Player winner;
        //private string p1Chosen;
        //private string p2chosen;
        private Player p1;
        private Player p2;

        public Player Winner { get => winner; set => winner = value; }
        public Player P1 { get => p1; set => p1 = value; }
        public Player P2 { get => p2; set => p2 = value; }

        public static int rounds;

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

        public string randomChoice()
        {
            // create an array of strings that will hold the values of "Rock", "Paper", "Scissors" to compare
            // and decide winner

            var random = new Random();
            var list = new List<string> { "Rock", "Paper", "Scissor" };
            int index = random.Next(3);
            return list[index];


        }
       

            /// <summary>
            /// This where the information about the round are display with the players names
            /// </summary>
            /// <param name="p1"></param>
            /// <param name="p2"></param>
      

        public void RoundPlayer()
        {
            rounds += 1;
            Console.WriteLine($"Round {rounds} | {P1.Name} VS {P2.Name}");
            //p1.playerHand = MakeAChoice();
            //p2.playerHand = MakeAChoice();
            P1.PlayerHand = randomChoice();
            Console.WriteLine(P1.PlayerHand);
            P2.PlayerHand = randomChoice();
            Console.WriteLine(P2.PlayerHand);
        }
    }


}
