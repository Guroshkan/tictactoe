using System;
using System.Collections.Generic;
using System.Text;

namespace tic_tac_toe
{
    class User
    {
        public virtual int ReadInteger()
        {
            for(; ; )
            {
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Incorrect input. Try Again.");
                }
            }
            
        }
    }
}
