using System.Collections.Specialized;
using System.Runtime.Intrinsics.X86;
using System;


class Program
    {
        static void Main(string[] args)
        {
            // Introductions
            Console.WriteLine("Do you want to play a game? (y/n)");
            string UserInput = Console.ReadLine().ToLower();
            if (UserInput == "y")
            {
                Console.WriteLine("Great! Let's play a game.");
            }
            else
            {
                Console.WriteLine("That's too bad. You are still playing anyways.");
            }

        // Create a new 3x3 game board
        char[] GameBoard = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        // Initialize a new instance of the SpencerClass
        SpencerClass game = new SpencerClass();

    
        // Initialize Move counter to start
        int MoveCounter = 0;

        // Initalize Player X and 0 on a turn basis. 
        char CurrentPlayer = 'X';


        while (MoveCounter < 9)
        {
            // Initial Print the Board
            game.PrintBoard(GameBoard);

            // Create a variable to store player inputs
            Console.WriteLine($"Player {CurrentPlayer}, which tile will you pick?");
            string PlayerInput = Console.ReadLine();

            // Validate the player input
            if (!int.TryParse(PlayerInput, out int tile) || tile < 1 || tile > 9 || GameBoard[tile - 1] == 'X' || GameBoard[tile - 1] == 'O')
            {
                Console.WriteLine("Invalid move. The tile is either already taken or out of range. Try again.");
                continue;
            }

            // Update the game board with the player's move
            GameBoard[tile - 1] = CurrentPlayer;

            // check for winner
            var (hasWinner, winner) = game.CheckWinner(GameBoard);
            if (hasWinner)
            {
                Console.WriteLine("We have a winner!");
                game.PrintBoard(GameBoard);
                Console.WriteLine("Congratulations!");
                Console.WriteLine($"Player {winner} wins!");
                break;
            }

            // Switch Players
            CurrentPlayer = CurrentPlayer == 'X' ? 'O' : 'X';
            MoveCounter++;
        }
            // In case of a draw (when the loop ends)
            if (MoveCounter == 9)
            {
                Console.WriteLine("It's a draw!");
            }
        }
    }
