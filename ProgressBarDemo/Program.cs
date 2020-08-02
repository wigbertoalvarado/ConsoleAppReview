using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgressBarDemo
{
   public class Program
    {
        public static void Main(string[] args)
        {

            ProgressBarUtility.WriteProgressBar(0);
            for (var i = 0; i <= 100; ++i)
            {
                ProgressBarUtility.WriteProgressBar(i, true);
                Thread.Sleep(50);
            }

            Console.WriteLine();
            ProgressBarUtility.WriteProgress(0);
            for (var i = 0; i <= 100; ++i)
            {
                ProgressBarUtility.WriteProgress(i, true);
                Thread.Sleep(50);
            }
        }
    }
}
