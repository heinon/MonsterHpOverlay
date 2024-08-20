using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class GameLauncher
{
    public const string MHW_STEAM_ID = "582010";

    public static void StartGame()
    {
        Process.Start(new ProcessStartInfo()
        { 
            FileName = $"steam://run/{MHW_STEAM_ID}",
            UseShellExecute = true
        });
    }
}
