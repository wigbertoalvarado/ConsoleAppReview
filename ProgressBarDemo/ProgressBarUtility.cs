using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressBarDemo
{
    public static class ProgressBarUtility
    {
        const char _block = '■';
        const string _back = "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b";
        const string _twirl = "-\\|/";

        public static void WriteProgressBar(int percent, bool update = false) 
        {
            if (update)
                Console.WriteLine(_back);

            Console.WriteLine("[]");
            var p = (int)((percent / 10f) + .5f);

            for (int i = 0; i < 10; i++)
            {
                if (i >= p)
                    Console.WriteLine(" ");
                else
                    Console.WriteLine(_block);
            }
            Console.Write("] {0,3:##0}%", percent);
        }

        public static void WriteProgress(int progress, bool update = false)
        {
            if (update)
                Console.WriteLine("\b");

            Console.WriteLine(_twirl[progress % _twirl.Length]);
        }
    }
       
}
