using System;

namespace tic_tac_toe
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ContinueGame = true;
            do
            {
                new TicTacToe();
                for(; ; )
                {
                    Console.WriteLine("You want play tic tac toe again? (Y/N)");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Y: ContinueGame = true; break;
                        case ConsoleKey.N: ContinueGame = false; break;
                        default: Console.WriteLine("Incorrect input. Try again."); continue;
                    }
                    break;
                }
            }
            while (ContinueGame);
        }
    }
}
