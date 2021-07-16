using System;
using Lab04_TicTacToe.Classes;

namespace Lab04_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }

        static void StartGame()
        {
            Player PlayerOne = new Player();
            Player PlayerTwo = new Player();
            Game Game = new(PlayerOne, PlayerTwo);
            Player Winner = Game.Play();

            if (Winner != PlayerOne || Winner != PlayerTwo)
            {
                Console.WriteLine("There was a draw!");
            }

            else
            {
                Console.WriteLine($"{Winner} Wins!");
            }
        }
    }
}