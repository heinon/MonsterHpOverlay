using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameIntegrationArgs : EventArgs
{
    public string? ProcessName { get; }
    public Process? Process { get; }

    public GameIntegrationArgs(string? processName, Process? process)
    {
        ProcessName = processName;
        Process = process;
    }
}
