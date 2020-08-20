using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReviewConsoleApp.Utils
{
    public interface IProgressBarConsole
    {
        Task Start(CancellationToken token);
    }
}
