﻿using System;

namespace Lab04_TicTacToe.Classes
{
    class Game
    {
        //initializing all objects to be used at a later date.
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public Player Winner { get; set; }
        public Board Board { get; set; }

        /// <summary>
        /// require 2 players and a board to start a game
        /// </summary> 

        public Game(Player p1, Player p2)
        {
            PlayerOne = p1;
            PlayerTwo = p2;
            Board = new Board();
        }

        /// <summary>
		/// Activate the Play of the game
		/// </summary>
		/// <returns>Winner</returns>
        public Player Play()
        {
            /*1. A turn consists of a player picking a position on the board with their designated marker. 
            2. Display the board after every turn to show the most up to date state of the game
            3. Once a Winner is determined, display the board one final time and return a winner
            Few additional hints:
                Be sure to keep track of the number of turns that have been taken to determine if a draw is required
                and make sure that the game continues while there are unmarked spots on the board. 
            Use any and all pre-existing methods in this program to help construct the method logic. 
             */

            /// Set the values of the marker string to each player.
                PlayerOne.Marker = "X";
                PlayerTwo.Marker = "O";
                PlayerOne.Name = "Player One";
                PlayerTwo.Name = "Player Two";
                
                Board.DisplayBoard();
            /// While iterator is less than 9, call up the next player by checking which player has a positive IsTurn boolean.
            /// the current player takes their turn with the function (chooses a number from the board.)
            bool winner = false;
                while (winner == false && PlayerOne.TurnAmount < 5 && PlayerTwo.TurnAmount < 5) 
                {
					Player currentPlayer = NextPlayer();
					currentPlayer.TakeTurn(Board);
					winner = CheckForWinner(Board);
					SwitchPlayer();
					Console.Clear();
					Board.DisplayBoard();
					if (winner == true) return Winner;
                }
                return Winner;
            
            // if all markers placed and no winner, create a draw;
        }
        /// <summary>
        /// Check if winner exists
        /// </summary>
        /// <param name="board">current state of the board</param>
        /// <returns>if winner exists</returns>
        public bool CheckForWinner(Board board)
        {
            int[][] winners = new int[][]
            {
                new[] {1,2,3},
                new[] {4,5,6},
                new[] {7,8,9},

                new[] {1,4,7},
                new[] {2,5,8},
                new[] {3,6,9},

                new[] {1,5,9},
                new[] {3,5,7}
            };

            // Given all the winning conditions, Determine the winning logic. 
            for (int i = 0; i < winners.Length; i++)
            {
                Position p1 = Player.PositionForNumber(winners[i][0]);
                Position p2 = Player.PositionForNumber(winners[i][1]);
                Position p3 = Player.PositionForNumber(winners[i][2]);

                string a = Board.GameBoard[p1.Row, p1.Column];
                string b = Board.GameBoard[p2.Row, p2.Column];
                string c = Board.GameBoard[p3.Row, p3.Column];

                // Checking the equality of the strings to see if they produce a three in a row with any of the orders
                // (stated above)
                if ((a == "X" && b == "X" && c == "X"))
                {
                    Winner = PlayerOne;
                    return true;
                }
                else if (a == "O" && b == "O" && c == "O")
                {
                    Winner = PlayerTwo;
                    return true;
                }
            } // if no winner is given, return false
            return false;
        }


        /// <summary>
        /// Determine next player
        /// </summary>
        /// <returns>next player</returns>
        public Player NextPlayer()
        {
            return (PlayerOne.IsTurn) ? PlayerOne : PlayerTwo;
        }

        /// <summary>
        /// End one players turn and activate the other
        /// </summary>
        public void SwitchPlayer()
        {
            if (PlayerOne.IsTurn)
            {
                PlayerOne.IsTurn = false;
                PlayerTwo.IsTurn = true;
            }
            else
            {
                PlayerOne.IsTurn = true;
                PlayerTwo.IsTurn = false;
            }
        }
    }
}
