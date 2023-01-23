using System;
using System.Threading;

namespace TicTacToeREAL
{
    class Program
    {
        static void Main(string[] args)
        {



            TicTacToe game = new TicTacToe();
            GameManager rule = new GameManager();
            Random random = new Random();

            game.LoadBoard();
            rule.FirstTurnPicker();

            //FIRST TURN
            if (rule.userTurn == true)
            {
                Console.WriteLine("You are going first!");
                Console.WriteLine("Please choose a spot:");
                game.ShowUserTurn(Console.ReadLine());
                rule.userTurn = false;
                rule.turnCount++;
            }
            else
            {
                Console.WriteLine("The computer is going first.");
                Console.WriteLine("Any key to begin:");
                Console.ReadLine();
                AI.NextTurn(game, rule);
                rule.userTurn = true;
                rule.turnCount++;
            }

            //SUBSEQUENT TURNS
            while (rule.maxTurns != rule.turnCount)
            {

                //Computer Turn
                if (rule.userTurn == false)
                {

                    Console.WriteLine("Hmmmm...");
                    Thread.Sleep(random.Next(500, 5000));
                    rule.userTurn = true;

                    bool win = rule.CheckForWin(game);
                    if (win == true)
                    {
                        rule.EndGameScreen();
                        rule.maxTurns = rule.turnCount;
                    }

                    AI.NextTurn(game, rule);


                }

                //User Turn
                else if (rule.userTurn == true)
                {

                    Console.WriteLine("Choose your spot:");
                    game.ShowUserTurn(Console.ReadLine());
                    rule.userTurn = false;

                    bool win = rule.CheckForWin(game);
                    if (win == true)
                    {
                        rule.EndGameScreen();
                        rule.maxTurns = rule.turnCount;
                    }

                }

                rule.turnCount++;   

            }

            rule.EndGameScreen();


        }
    }
}
