using System;
using System.Collections.Generic;
namespace TicTacToeREAL
{
    public class AI
    {

        public static List<int> spotsTakenUser = new List<int>();
        public static List<int> spotsTakenAI = new List<int>();
        public static List<int> spotsOpen = new List<int>();
        public static List<int> corners = new List<int> { 0, 2, 6, 8 };
        public static List<int> middleEdges = new List<int> { 1, 3, 5, 7 };
        public static List<List<int>> goodMoves = new List<List<int>>();
        public static bool computerStarted;


        public static void ReadBoard()
        {
            int iteration = 0;
            spotsOpen.Clear();
            spotsTakenAI.Clear();
            spotsTakenUser.Clear();

            foreach (char status in TicTacToe.boardPlacements)
            {

                if (status == 'X')
                {
                    spotsTakenUser.Add(iteration);
                }
                else if (status == 'O')
                {
                    spotsTakenAI.Add(iteration);
                }
                else if (status == '*')
                {
                    spotsOpen.Add(iteration);
                }

                iteration++;

            }
        }

        public static void NextTurn(TicTacToe currentGame, GameManager gameinfo)
        {

            Random random = new Random();
            //Reading the board

            ReadBoard();

            //Generating the next move


            //Turn 1 Logic
            if (gameinfo.turnCount == 0)
            {

                int randomInt = random.Next(2);

                if (randomInt == 0)
                {
                    TicTacToe.boardPlacements[4] = 'O';
                }
                else
                {
                    int whichCorner = random.Next(4);

                    if (whichCorner == 0)
                    {
                        TicTacToe.boardPlacements[0] = 'O';
                    }
                    else if (whichCorner == 1)
                    {
                        TicTacToe.boardPlacements[2] = 'O';
                    }
                    else if (whichCorner == 2)
                    {
                        TicTacToe.boardPlacements[6] = 'O';
                    }
                    else if (whichCorner == 3)
                    {
                        TicTacToe.boardPlacements[8] = 'O';
                    }
                }

                currentGame.LoadBoard();
                return;

            }

            //Subsequent turn logic

            //Always fill the middle if its open
            else if (spotsOpen.Contains(4) == true)
            {
                TicTacToe.boardPlacements[4] = 'O';
                currentGame.LoadBoard();
                return;
            }

            //If user takes middle on first turn, choose a random corner
            else if (gameinfo.turnCount == 1 && spotsTakenUser.Contains(4) == true)
            {
                int whichCorner = random.Next(4);

                if (whichCorner == 0)
                {
                    TicTacToe.boardPlacements[0] = 'O';
                }
                else if (whichCorner == 1)
                {
                    TicTacToe.boardPlacements[2] = 'O';
                }
                else if (whichCorner == 2)
                {
                    TicTacToe.boardPlacements[6] = 'O';
                }
                else if (whichCorner == 3)
                {
                    TicTacToe.boardPlacements[8] = 'O';
                }

                currentGame.LoadBoard();
                return;
            }

            //Check if the computer can win and make that move.
            if (spotsTakenAI.Count >= 2)
            {
                foreach (List<int> winningMove in gameinfo.winningMoves)
                {
                    int indexWithNoMatch = 0;
                    int matches = 0;
                    int iteration_ = 0;

                    foreach (int move in winningMove)
                    {

                        if (spotsTakenAI.Contains(move) == true)
                        {
                            matches++;
                        }
                        else
                        {
                            indexWithNoMatch = move;
                        }

                        iteration_++;

                        if (iteration_ == 3 && matches == 2 && spotsTakenUser.Contains(indexWithNoMatch) == false)
                        {
                            TicTacToe.boardPlacements[indexWithNoMatch] = 'O';
                            currentGame.LoadBoard();
                            return;
                        }

                    }

                }
            }
            

            //Check if the user is threatening checkmate and block

            if (spotsTakenUser.Count >= 2)
            {
                foreach (List<int> winningMove in gameinfo.winningMoves)
                {

                    int indexWithNoMatch = 0;
                    int matches = 0;
                    int _iteration = 0;

                    foreach (int move in winningMove)
                    {

                        if (spotsTakenUser.Contains(move) == true)
                        {
                            matches++;
                        }
                        else
                        {
                            indexWithNoMatch = move;
                        }

                        _iteration++;

                        if (_iteration == 3 && matches == 2 && spotsTakenAI.Contains(indexWithNoMatch) == false)
                        {
                            TicTacToe.boardPlacements[indexWithNoMatch] = 'O';
                            currentGame.LoadBoard();
                            return;
                        }

                    }

                }
            }

            //If AI is on offense, do this.

            //Start by getting vision of all possible moves that can win you the game in less than two turns.
            goodMoves.Clear();

            foreach (List<int> winningMove in gameinfo.winningMoves)
            {

                bool isGood = false;
                List<int> temp = new List<int>();


                foreach (int move in winningMove)
                {
                    if (spotsOpen.Contains(move) == true)
                    {
                        isGood = true;
                        int temp2 = move;
                        temp.Add(temp2);
                    }
                }

                if (isGood == true)
                {
                    goodMoves.Add(temp);
                }
            }

            //Choose a random move within that list and perform it

            int randomWinnerMove = random.Next(0, goodMoves.Count);
            int doThisMove = random.Next(0, goodMoves[randomWinnerMove].Count);
            int finalMove = goodMoves[randomWinnerMove][doThisMove];

            TicTacToe.boardPlacements[finalMove] = 'O';
            currentGame.LoadBoard();
            return;
            


        }

    }
}
