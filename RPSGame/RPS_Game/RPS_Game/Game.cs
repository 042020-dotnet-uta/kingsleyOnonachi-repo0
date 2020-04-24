using System;
using System.Collections.Generic;
using System.Text;

namespace RPS_Game
{
    class Game
    {
        public List<Round> Rounds { get; set; }
        public Player player1 = new Player();
        public Player player2 = new Player();

        public void startGame()
        {

            // ask for input of player1 and player 2's  name and store it their respective property
            Console.WriteLine("Enter first player name:");
            player1.Name = Console.ReadLine();

            Console.WriteLine("Enter second player name:");
            player2.Name = Console.ReadLine();

            Console.WriteLine($"Player1's name is: {player1.Name}");
            Console.WriteLine($"Player2's name is: {player2.Name}");
        }
    }

    
}
