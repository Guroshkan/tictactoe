using System;
using System.Collections.Generic;
using System.Text;

namespace tic_tac_toe
{
    partial class TicTacToe
    {
        class Rules
        {
            public const int StandartMinimumValue = 3;
            public const int StandartMaxmumValue = 5;
            int InRow;

            public Rules(int SizeField)
            {
                this.InRow = SizeField == StandartMinimumValue ? StandartMinimumValue : 
                    SizeField <= StandartMaxmumValue + 1 ? SizeField - 1 : StandartMaxmumValue;
            }

            public bool CheckBlock(char Mark, List<List<Point>> matrix, int posX, int posY)
            {
                //lanes
                bool cols, rows;
                for (int col = posX; col < this.InRow + posX; col++)
                {
                    cols = true;
                    rows = true;
                    for (int row = posY; row < this.InRow + posY; row++)
                    {
                        cols &= (matrix[col][row].Value == Mark);
                        rows &= (matrix[row][col].Value == Mark);
                    }
                    if (cols || rows) return true;
                }
                //diagonals
                bool toright = true, toleft = true;
                for (int i = 0; i < this.InRow; i++)
                {
                    toright &= (matrix[i+posX][i+posY].Value == Mark);
                    toleft &= (matrix[this.InRow - i - 1 + posX][i + posY].Value == Mark);
                }
                return (toright || toleft);
            }

            public bool CheckWin(char Mark, List<List<Point>> matrix)
            {
                if(matrix.Count != StandartMinimumValue)
                {
                    for (int i = 0; i <= matrix.Count - this.InRow; i++)
                    {
                        for (int j = 0; j <= matrix.Count - this.InRow; j++)
                        {
                            if (this.CheckBlock(Mark, matrix, i, j))
                                return true;
                        }
                    }
                    return false;
                } 
                else
                {
                    return this.CheckBlock(Mark, matrix, 0, 0);
                }
                
            }
        }
    }
}
