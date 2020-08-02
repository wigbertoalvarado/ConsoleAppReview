using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor colorBack = Console.BackgroundColor;
            ConsoleColor colorFore = Console.ForegroundColor;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkCyan;

            Console.SetCursorPosition(1,1);

            for (int i =0; i <= 100; i++) 
            {
                for (int j =0; j < i; j++) 
                {
                    Console.Write("█");
                }

                Console.Write(i+"/100");
                Console.SetCursorPosition(1,1);
                System.Threading.Thread.Sleep(100);
                
            }
        }
       
    }
}
