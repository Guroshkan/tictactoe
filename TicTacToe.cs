using System;
using System.Collections.Generic;
using System.Text;

namespace tic_tac_toe
{
    partial class TicTacToe
    {   
        public TicTacToe()
        {
            Player winner = new Game().Start();
            if (!(winner is null))
                Console.WriteLine($"Congratulation Player {winner.IdPlayer} - you won!");
            else
                Console.WriteLine("Draw in this game.");
        }
        class Game
        {
            List<Player> players;
            Field field;
            Player CurrPlayer;
            Rules rule;
            int FreeCells;
            public Game()
            {
                players = new List<Player>();
                players.Add(new Player(((char)Values.X)));
                players.Add(new Player(((char)Values.O)));
                CurrPlayer = players[0];

                Console.WriteLine("Size Field is:");
                int size = players[0].GetSizeField();
                field = new Field(size);
                rule = new Rules(size);
                FreeCells = size * size;
                Console.Clear();
            } 

            public Player Start()
            {
                Monitor.Display(field);
                for(; ; )
                {
                    try
                    {
                        Console.WriteLine($"Player {CurrPlayer.IdPlayer}({CurrPlayer.Mark}) your turn.");
                        CurrPlayer.MakeMove(field);
                        FreeCells--;
                        Console.Clear();
                        if (rule.CheckWin(CurrPlayer.Mark, field.matrix)) // check who won
                        {
                            players[0].Dispose();
                            players[1].Dispose();
                            return CurrPlayer;
                        }
                        if (FreeCells == 0)//draw situation
                        {
                            players[0].Dispose();
                            players[1].Dispose();
                            return null;
                        }
                        ChangePlayer();
                    }
                    catch (RewritingValueException e)
                    {
                        Console.Clear();
                        Console.WriteLine($"You can't rewrite value in position x = {e.x}, y = {e.y}");
                    }
                    catch (IndexOutOfFieldException e)
                    {
                        Console.Clear();
                        Console.WriteLine($"Position x = {e.x}, y = {e.y} does not exist. Try again.");
                    }
                    finally
                    {
                        Monitor.Display(field);
                    }
                }
            }

            void ChangePlayer()
            {
                CurrPlayer = CurrPlayer.IdPlayer < players.Count ? players[players.IndexOf(CurrPlayer) + 1] : players[0]; //round robin change players
            }
        }
    }
}
