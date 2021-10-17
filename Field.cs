using System;
using System.Collections.Generic;
using System.Text;

namespace tic_tac_toe
{
    partial class TicTacToe
    {
        public class Field
        {
            public List<List<Point>> matrix;
            public List<Point> tmp;
            int Size;

            public Field(int size)
            {
                matrix = new List<List<Point>>();
                this.Size = size;
                for (int i = 0; i < this.Size; i++)
                {
                    var str = new List<Point>();
                    for (int j = 0; j < size; j++)
                    {
                        str.Add(new Point());
                    }
                    matrix.Add(str);
                }
            }

            public int Length()
            {
                return this.Size;
            }
        }
    }
}
