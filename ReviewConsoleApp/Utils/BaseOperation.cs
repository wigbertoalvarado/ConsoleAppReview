using ShellProgressBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReviewConsoleApp.Utils
{
    public abstract class BaseOperation : IProgressBarConsole
    {
        private bool RequestToQuit { get; set; }

        protected void TickToCompletion(IProgressBar pbar, int ticks, int sleep = 1750, Action<int> childAction = null)
        {
            var initialMessage = pbar.Message;
            for (var i = 0; i < ticks && !RequestToQuit; i++)
            {
                pbar.Message = $"Start {i + 1} of {ticks} {Console.CursorTop}/{Console.WindowHeight}: {initialMessage}";
                childAction?.Invoke(i);
                Thread.Sleep(sleep);
                pbar.Tick($"End {i + 1} of {ticks} {Console.CursorTop}/{Console.WindowHeight}: {initialMessage}");
            }
        }

        public Task Start(CancellationToken token)
        {
            RequestToQuit = false;
            token.Register(() => RequestToQuit = true);

            this.Start();
            return Task.FromResult(1);
        }

        protected abstract void Start();
    }
}
