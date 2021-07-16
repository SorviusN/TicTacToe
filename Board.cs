using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_TicTacToe.Classes
{
	class Board
	{
		/// <summary>
		/// Tic Tac Toe Gameboard states
		/// </summary>
		public string[,] GameBoard = new string[,] // multi-dimensional array
		{
			{"1", "2", "3"},
			{"4", "5", "6"},
			{"7", "8", "9"},
		};

		// Displays the board for the player to see in the console.
		public void DisplayBoard() 
		{
			Console.WriteLine(GameBoard);
		}
	}
}
