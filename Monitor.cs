using System;
using System.Collections.Generic;
using System.Text;

namespace tic_tac_toe
{
    static class Monitor
    {
        public static void Display(TicTacToe.Field field)
        {
            Console.Write('\t');
            for (int i = 0; i < field.Length(); i++)
            {
                Console.Write($" {i + 1}\t");
            }
            Console.Write("→ Y");
            Console.WriteLine();
            for (int i = 0; i < field.Length(); i++)
            {
                Console.Write($"{i+1}\t");
                for (int j = 0; j < field.Length(); j++)
                {
                    Console.Write($"|{field.matrix[i][j].Value}|\t");
                }
                Console.Write("\n\n");
            }
            Console.WriteLine("↓");
            Console.WriteLine("X");
        }
    }
}
