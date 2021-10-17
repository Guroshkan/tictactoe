using System;
using System.Collections.Generic;
using System.Text;


namespace tic_tac_toe
{
    class ExcessPlayers : Exception { }
    class PointException : Exception
    {
        public int x, y;
        public PointException(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class RewritingValueException : PointException
    {
        public RewritingValueException(int x, int y) : base(x, y) { }
    }
    class IndexOutOfFieldException : PointException
    {
        public IndexOutOfFieldException(int x, int y) : base(x, y) { }
    }

    partial class TicTacToe
    {
        const int MAXPLAYERS = 2;
        class Player:User, IDisposable
        {
            public static int CountPlayer;
            public int IdPlayer;
            public char Mark;
            public Player(char mark)
            {
                CountPlayer++;
                IdPlayer = CountPlayer <= MAXPLAYERS ? CountPlayer : throw new ExcessPlayers();
                this.Mark = mark;
            }
            public void Dispose()
            {
                CountPlayer--;
            }

            public void MakeMove(Field field)
            {
                Console.WriteLine($"CHoose position x from 1 to {field.Length()}");
                int XCoord = this.ReadInteger() - 1;
                Console.WriteLine($"CHoose position y from 1 to {field.Length()}");
                int YCoord = this.ReadInteger() - 1;
                try 
                {
                    if (CheckPosition(field.matrix[XCoord][YCoord].Value))
                    {
                        field.matrix[XCoord][YCoord].Value = this.Mark;
                    }
                    else
                        throw new RewritingValueException(XCoord + 1, YCoord + 1);
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new IndexOutOfFieldException(XCoord + 1, YCoord + 1);
                }
            }
            bool CheckPosition(char ValueInPosition)
            {
                return ValueInPosition == ((char)Values.empty);
            }
            public int GetSizeField()
            {
                Console.WriteLine($"Player {this.IdPlayer} get a size of field.");
                for(; ; )
                {
                    int size = this.ReadInteger();
                    if(size<Rules.StandartMinimumValue)
                    {
                        Console.WriteLine($"Size can't  be less then {Rules.StandartMinimumValue}");
                        continue;
                    }
                    return size;
                }
            }
        }
    }
}
