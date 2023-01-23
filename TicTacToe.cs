using System;
using System.Collections.Generic;

namespace TicTacToeREAL
{
    public class TicTacToe
    {

        public static List<char> boardPlacements = new List<char> {'*', '*', '*', '*', '*', '*', '*', '*', '*', };

        public void LoadBoard()
        {
            Console.Clear();
            Console.WriteLine("     Tic-Tac-Toe");
            Console.WriteLine("---------------------");
            Console.WriteLine("      1   2   3");
            Console.WriteLine("    /-----------\\");
            Console.WriteLine($"  A | {boardPlacements[0]} | {boardPlacements[1]} | {boardPlacements[2]} |");
            Console.WriteLine("    |---|---|---|");
            Console.WriteLine($"  B | {boardPlacements[3]} | {boardPlacements[4]} | {boardPlacements[5]} |");
            Console.WriteLine("    |---|---|---|");
            Console.WriteLine($"  C | {boardPlacements[6]} | {boardPlacements[7]} | {boardPlacements[8]} |");
            Console.WriteLine("    \\---|---|---/");
            Console.WriteLine();
        }

        public void ShowUserTurn(string userInput)
        {

            userInput.ToUpper();

            if (userInput == "A1")
            {
                boardPlacements[0] = 'X';
                LoadBoard();
            }
            else if (userInput == "A2")
            {
                boardPlacements[1] = 'X';
                LoadBoard();
            }
            else if (userInput == "A3")
            {
                boardPlacements[2] = 'X';
                LoadBoard();
            }
            else if (userInput == "B1")
            {
                boardPlacements[3] = 'X';
                LoadBoard();
            }
            else if (userInput == "B2")
            {
                boardPlacements[4] = 'X';
                LoadBoard();
            }
            else if (userInput == "B3")
            {
                boardPlacements[5] = 'X';
                LoadBoard();
            }
            else if (userInput == "C1")
            {
                boardPlacements[6] = 'X';
                LoadBoard();
            }
            else if (userInput == "C2")
            {
                boardPlacements[7] = 'X';
                LoadBoard();
            }
            else if (userInput == "C3")
            {
                boardPlacements[8] = 'X';
                LoadBoard();
            }
            else
            {
                LoadBoard();
                Console.WriteLine("Please enter a valid space:");
                ShowUserTurn(Console.ReadLine());
            }

        }

    }
}
