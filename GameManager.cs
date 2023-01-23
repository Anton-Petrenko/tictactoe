using System;
using System.Collections.Generic;

namespace TicTacToeREAL
{
    public class GameManager
    {

        public int turnCount = 0;
        public int maxTurns = 9;
        public bool userTurn;
        public bool userWin = false;
        public bool computerWin = false;
        public List<List<int>> winningMoves = new List<List<int>>();
     
        public GameManager()
        {

            winningMoves.Add(new List<int> { 0, 1, 2 });
            winningMoves.Add(new List<int> { 3, 4, 5 });
            winningMoves.Add(new List<int> { 6, 7, 8 });
            winningMoves.Add(new List<int> { 0, 3, 6 });
            winningMoves.Add(new List<int> { 1, 4, 7 });
            winningMoves.Add(new List<int> { 2, 5, 8 });
            winningMoves.Add(new List<int> { 0, 4, 8 });
            winningMoves.Add(new List<int> { 2, 4, 6 });

        }
        


        public void FirstTurnPicker()
        {
            Random random = new Random();
            int turn = random.Next(0, 2);

            if (turn == 1)
            {
                userTurn = true;
            }
            else
            {
                userTurn = false;
            }
        }

        public bool CheckForWin(TicTacToe currentGame)
        {


            foreach (List<int> winningMove in winningMoves)
            {

                int numX = 0;
                int numO = 0;

                foreach (int placement in winningMove)
                {

                    if (TicTacToe.boardPlacements[placement] == 'X')
                    {

                        numX++;

                        if (numX == 3)
                        {
                            userWin = true;
                            return true;
                        }

                    }
                    else if (TicTacToe.boardPlacements[placement] == 'O')
                    {

                        numO++;

                        if (numO == 3)
                        {
                            computerWin = true;
                            return true;
                        }

                    }

                }

            }

            return false;


        }

        public void EndGameScreen()
        {

            if (computerWin == true)
            {
                Console.WriteLine("You lost!");
            }
            else if (userWin == true)
            {
                Console.WriteLine("You won!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }

            Environment.Exit(0);

        }


    }
}
