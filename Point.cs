using System;
using System.Collections.Generic;
using System.Text;
public enum Values {X = 'X', O = 'O', empty = ' '};

namespace tic_tac_toe
{
    public class Point
    {
        public char Value;
        public Point()
        {
            Value = (char)Values.empty;
        }
        public Point(Values v)
        {
            Value = (char)v;
        }
    }
}
