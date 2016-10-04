using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeByWolf
{
    class Program
    {
        // Start Settings

        bool randomizeStartingPlayer = false; /// doesn't work as of 03-10-16 16:55
        // bool antiCheatAI = false;
        // bool AI = false;

        // End Setting

        // Start Varibles

        char[,] board = new char[3, 3] { {' ', ' ', ' '},
                                         {' ', ' ', ' '},
                                         {' ', ' ', ' '}};
        bool game;
        int actioncounter;
        string choice;
        bool running = true;
        char player = ' ';
        int[] piececounter = new int[2] {0, 0}; // slot 0 is for x, and slot 1 is for o
        char startingPlayer;

        // End Varibles

        // Start Program

        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.run();
        }

        private void run()
        {
            while (running == true)
            {
                ShowMenu();
                choice = GetUserChoiceForMenu();
                switch (choice)
                {
                    case "1":
                        SetStartingPlayer();
                        game = true;
                        actioncounter = 0;
                        piececounter[0] = 0;
                        piececounter[1] = 0;
                        ShowBlankBoard();
                        ShowBoard();
                        Console.WriteLine("Player " + startingPlayer + " starts" );
                        while (game == true)
                        {
                            ChosePiecePos();

                            ShowBoard();

                            if (CheckIfGameOver() == true)
                            {
                                GameOver();
                            }
                            SwapPlayer();

                            if (CheckIfPlayerHasThreePieces() == true)
                            {
                                MovePiece();
                            }

                            actioncounter++;
                        }
                        break;
                    case "9":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Something went wrong or you chose a invalid number / charecter");
                        break;
                }
            }
 
        }
        // End Program

        // Start Methods

        private void SwapPlayer()
        {
            if (player == 'x')
            {
                player = 'o';
                Console.WriteLine("Players o's Turn");
            }
            else
            {
                player = 'x';
                Console.WriteLine("Player x's Turn");
            }
        }

        private void ChosePiecePos()
        {
            int tempx = 0;
            int tempy = 0;
            int xcord = 0;
            int ycord = 0;

            Console.WriteLine("What is the x cordinat of the place you wish to place at?");
            Console.WriteLine("x: ");
            Int32.TryParse(Console.ReadLine(), out tempx);
            
            if (0 <= tempx && tempx <= 2)
            {
                xcord = tempx;
            }
            else
            {
                Console.WriteLine("Invalid x number or charecter, try again");
                Console.ReadLine();
                ChosePiecePos();
            }

            Console.WriteLine("What is the y cordinat of the place you wish to place at?");
            Console.WriteLine("y: ");
            Int32.TryParse(Console.ReadLine(), out tempy);

            if (0 <= tempy && tempy <= 2)
            {
                ycord = tempy;
            }
            else
            {
                Console.WriteLine("Invalid y number or charecter, try again");
                Console.ReadLine();
                ChosePiecePos();
            }

            if (board[xcord, ycord] == ' ')
            {
                board[xcord, ycord] = player;
            }
            else
            {
                Console.WriteLine("That slot already has a piece in it, try another");
                ChosePiecePos();
            }
            

            if (board[xcord, ycord] == player)
            {
                if (player == 'x')
                {
                    if (0 <= piececounter[0] && piececounter[0] <= 2)
                    {
                        piececounter[0]++;
                    }
                }
                if (player == 'o')
                {
                    if (0 <= piececounter[1] && piececounter[1] <= 2)
                    {
                        piececounter[1]++;
                    }
                }
            }
            
        }

        private bool CheckIfPlayerHasThreePieces()
        {
            switch (player)
            {
                case 'x':
                    if (piececounter[0] == 3)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 'o':
                    if (piececounter[1] == 3)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
               default:
                    return false;
                    
            }
        }

        private bool CheckIfGameOver()
        {
            if (CheckIfPlayerHasThreePieces() == true)
            {
                if ((board[0, 0] == board[1, 0] && board[0, 0] == board[2, 0]
                    || board[0, 1] == board[1, 1] && board[0, 1] == board[2, 1]
                    || board[0, 2] == board[1, 2] && board[0, 2] == board[2, 2]
                    || board[0, 0] == board[0, 1] && board[0, 0] == board[0, 2]
                    || board[1, 0] == board[1, 1] && board[1, 0] == board[1, 2]
                    || board[2, 0] == board[2, 1] && board[2, 0] == board[2, 2]
                    || board[2, 0] == board[1, 1] && board[2, 0] == board[0, 2]
                    || board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void ShowBoard()
        {
            Console.WriteLine(" " + board[0, 0] + " | " + board[1, 0] + " | " + board[2, 0] + " ");
            Console.WriteLine("---|---|---");
            Console.WriteLine(" " + board[0, 1] + " | " + board[1, 1] + " | " + board[2, 1] + " ");
            Console.WriteLine("---|---|---");
            Console.WriteLine(" " + board[0, 2] + " | " + board[1, 2] + " | " + board[2, 2] + " ");
        }

        private void ShowBlankBoard()
        {
            Console.WriteLine(" 0,0 | 1,0 | 2,0 ");
            Console.WriteLine("-----|-----|-----");
            Console.WriteLine(" 0,1 | 1,1 | 2,1 ");
            Console.WriteLine("-----|-----|-----");
            Console.WriteLine(" 0,2 | 1,2 | 2,2 ");
            Console.WriteLine("Remember these cordinates as they are used to play the game");
        }

        private void SetStartingPlayer()
        {
            if (randomizeStartingPlayer == false)
            {
                player = 'o';
                startingPlayer = player;
            }
            else
            {
                Random random = new Random();
                int number = random.Next(2);

                switch (number)
                {
                    case 1:
                        player = 'x';
                        startingPlayer = player;
                        break;
                    case 2:
                        player = 'o';
                        startingPlayer = player;
                        break;
                    default:
                        Console.WriteLine("Something went wrong while choseing starting player");
                        break;
                }
            }
        }

        private string GetUserChoiceForMenu()
        {
            Console.WriteLine("Type your choice: ");
            string temp = Console.ReadLine();
            return temp;
        }

        private void ShowMenu()
        {
            Console.WriteLine("1 = New Tic Tac Toe Game");
            Console.WriteLine("9 = Exit");
        }

        private void MovePiece()
        {
            int tempx;
            int tempy;
            int xcord = 0;
            int ycord = 0;

            Console.WriteLine("You have 3 pieces on the board already");
            Console.WriteLine("What is the x cordinat of the piece you wish to move?");
            Console.WriteLine("x: ");
            Int32.TryParse(Console.ReadLine(), out tempx);

            if (0 <= tempx && tempx <= 2)
            {
                xcord = tempx;
            }
            else
            {
                Console.WriteLine("Invalid x number or charecter, try again");
                MovePiece();
            }

            Console.WriteLine("What is the y cordinat of the peice you wish to move?");
            Console.WriteLine("y: ");
            Int32.TryParse(Console.ReadLine(), out tempy);

            if (0 <= tempy && tempy <= 2)
            {
                ycord = tempy;
            }
            else
            {
                Console.WriteLine("Invalid y number or charecter, try again");
                MovePiece();
            }

            if (board[xcord, ycord] == player)
            {
                board[xcord, ycord] = ' ';
            }
            else
            {
                Console.WriteLine("That slot is empty or not yours, try another");
                MovePiece();
            }
            

            if (board[xcord, ycord] == player)
            {
                if (player == 'x')
                {
                    if (0 <= piececounter[0] && piececounter[0] <= 2)
                    {
                        piececounter[0]--;
                    }
                }
                if (player == 'o')
                {
                    if (0 <= piececounter[1] && piececounter[1] <= 2)
                    {
                        piececounter[1]--;
                    }
                }
            }
        }

        private void GameOver()
        {
            Console.WriteLine("Player " + player + " have won the game");
            Console.WriteLine("The game had " + actioncounter + " actions");
            game = false;
            Console.ReadLine();
        }
        // End Methods

        // Start Overides

        // End Overides
    }
}
