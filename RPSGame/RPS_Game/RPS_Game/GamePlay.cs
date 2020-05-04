using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace RPS_Game
{
    public class GamePlay
    {
        private Player p1 = new Player();
        private Player p2 = new Player();
        private static Game game;
        private  int p1Wins; // win count for player 1
        private  int p2Wins; // win count for player 2
        //private static int ties = 0;
        
        //install the logger for a console app.
        private readonly ILogger _logger;
        public GamePlay(ILogger<GamePlay> logger)
        {
            _logger = logger;
        }


        //get the users data

        public void StartGame()
        {
           /* _logger.LogInformation("LogInformation = Hello. My name is Log LogInformation");
            _logger.LogWarning("LogWarning = At {time} Now I'm Loggy McLoggerton", DateTime.Now);
            _logger.LogCritical("LogCritical = As of now, I'm Scrog McLog");
            _logger.LogDebug("Log Debug");//not printed to console
            _logger.LogError("LogError");
            _logger.LogTrace("Log Trace = Tracing my way back home.");//not printed to console
            // ask for input of player1 and player 2's  name and store it their respective property*/



            Console.WriteLine("\nEnter first player name:");
            p1.Name = Console.ReadLine();
            Console.WriteLine("Enter second player name:");
            p2.Name = Console.ReadLine();

            Console.WriteLine($"Player1's name is: {p1.Name}");
            Console.WriteLine($"Player2's name is: {p2.Name}");
        }
        public void RunGame()
        {
            //create the game with players

            game = new Game();
            //run rounds till a player has 2 wins. 
            while (p1Wins < 2 && p2Wins < 2)
            {
                
                Round r1 = new Round { 
                P1 = p1,
                P2 = p2};
                r1.RoundPlayer();
                Console.WriteLine("The winner is ",r1.Winner);
                
                game.Rounds.Add(r1);
            }

            AssignWinner();
        }

        /// <summary>
        /// this method runs one round
        /// </summary>
        private Round RunRound()
        {

            //create a round to hold the data for this round
            //Console.WriteLine(p1.wins + p2.wins);
            Round oneRound = new Round();
            oneRound.RoundPlayer();
            return DetermineRoundWinner(oneRound);

        }

        /// <summary>
        /// This method takes the choices of p1 and p2 and determins a winner
        /// It also updates all model fields according to the winner.
        /// </summary>
        /// <param name="p1rand"></param>
        /// <param name="p2rand"></param>
        /// <param name="oneRound"></param>
        /// <returns></returns>
        private Round DetermineRoundWinner(Round oneRound)
        {
            //int win = p1rand - p2rand + 2;//determine the winner
             
            if (oneRound.P1.PlayerHand == oneRound.P2.PlayerHand)
            {
                Console.WriteLine("We have a tie");
                 oneRound.Winner = null;
                 return oneRound;
            }
            else if ((oneRound.P1.PlayerHand == "Rock" && oneRound.P2.PlayerHand == "Scissor") || (oneRound.P1.PlayerHand == "Scissor" && oneRound.P2.PlayerHand == "Paper") || (p1.PlayerHand == "Paper" && oneRound.P2.PlayerHand == "Rock"))
            {
                oneRound.Winner = p1;
                p1.wins += 1;
                p2.losses += 1;
                Console.WriteLine($"Player {oneRound.Winner} wins.");
                return oneRound;
                

            }
            else
            {
                oneRound.Winner = p2;
                p1.losses += 1;
                p2.wins += 1;
                //Console.WriteLine($"Player {player2.playerName} wins.");
                Console.WriteLine($"Player {oneRound.Winner} wins.");
                return oneRound;
            }

        }

        public void AssignWinner()
        {
            if (game.Winner == p1)
            {
                game.Winner = game.Player1;  //assign the winner to the winners spot in the game
                p1Wins = game.Player1.wins;     //increment the winners wins
                //increment the loosers losses
            }
            else if (game.Winner == p2)
            {
                game.Winner = game.Player2;  //assign the winner to the winners spot in the game
                p2Wins = game.Player2.wins;     //increment the winners wins
                game.Player1.losses++;       //increment the loosers losses
            }
            else
            {
                //just in case the wrong number of games is played
                _logger.LogDebug("something happened and neither player won with 2 wins.");
            }
        }


    //}

    //check the p1Wins and p2Wins to see who won.


    // Print the results bases on the objects 
    public void PrintResults()
        {   
            int r = 1;
            foreach (var round in game.Rounds)
            {
                if (round.Winner == null) 
                {
                    Console.WriteLine($"In round {r}, there was no winner because {game.Player1.Name} chose {round.P1.PlayerHand} and {game.Player2.Name} chose {round.P2.PlayerHand}.");
                }
                else if (round.Winner != null && round.Winner == round.P1)
                {
                    Console.WriteLine($"In round {r}, {round.Winner.Name} won by choosing {round.P1.PlayerHand} over {game.Player2.Name}'s {round.P2.PlayerHand}.");
                }
                else
                {
                    Console.WriteLine($"In round {r}, {round.Winner.Name} won by choosing {round.P2} over {game.Player1.Name}'s {round.P1.PlayerHand}.");
                }
                r++;
            }

            Console.WriteLine($"Overall, {game.Winner.Name} won.");
        }
    }
}
