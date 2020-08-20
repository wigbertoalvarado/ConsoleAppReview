using ShellProgressBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewConsoleApp.Utils
{
    public class StylingProgressBar : BaseOperation
    {
        protected override void Start()
        {
            const int totalTicks = 10;
            var options = new ProgressBarOptions
            {
                ForegroundColor = ConsoleColor.Yellow,
                ForegroundColorDone = ConsoleColor.DarkGreen,
                BackgroundColor = ConsoleColor.DarkGray,
                BackgroundCharacter = '\u2593'
            };
            using (var pbar = new ProgressBar(totalTicks, "showing off styling", options))
            {
                TickToCompletion(pbar, totalTicks, sleep: 500, i =>
                {
                    if (i > 5) pbar.ForegroundColor = ConsoleColor.Red;
                });
            }
        }
    }
}
