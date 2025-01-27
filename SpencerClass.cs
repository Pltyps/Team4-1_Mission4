using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SpencerClass
{
    // Method to print the board
    public void PrintBoard(char[] board)
    {
        for (int i = 1; i <= board.Length; i++) // Adjusted to 1-based indexing
        {
            Console.Write($" {board[i - 1]} "); // Access array using 0-based index
            if (i % 3 == 0)
            {
                Console.WriteLine(); // New line after every row
                if (i < 9) Console.WriteLine("---+---+---"); // Horizontal separator
            }
            else
            {
                Console.Write("|"); // Vertical separator
            }
        }
    }

    // Method to check for a winner
    public (bool hasWinner, char winner) CheckWinner(char[] board)
    {
        // Winning combinations based on 1-based indexing
        int[][] winningCombinations = new int[][]
        {
            // Rows
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9 },
            // Columns
            new int[] { 1, 4, 7 },
            new int[] { 2, 5, 8 },
            new int[] { 3, 6, 9 },
            // Diagonals
            new int[] { 1, 5, 9 },
            new int[] { 3, 5, 7 }
        };

        // Check each combination (adjust indices to 0-based for array access)
        foreach (var combo in winningCombinations)
        {
            if (board[combo[0] - 1] != ' ' && // Convert 1-based to 0-based
                board[combo[0] - 1] == board[combo[1] - 1] &&
                board[combo[1] - 1] == board[combo[2] - 1])
            {
                return (true, board[combo[0] - 1]); // Return the winning player
            }
        }

        // No winner found
        return (false, ' ');
    }
}
