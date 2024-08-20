using MonsterHpOverlay.Core.GameData.Game;
using System.Diagnostics;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace MonsterHpOverlay.Integration
{
    public class GameIntegrationService
    {
        public string ProcessName = "MonsterHunterWorld";
        private IntPtr pHandle;
        public const long MONSTER_ADDRESS = 0x05121688;
        public const long BASE = 0x140000000;
        public static readonly int[] MONSTER_OFFSET = new int[] { 0x698, 0x0, 0x138, 0x0 };

        public static event EventHandler<GameIntegrationArgs>? GameIntegrationServiceLoaded;
        public void Start()
        {
            var mhProcess = Process.GetProcessesByName(ProcessName).FirstOrDefault();
            if (mhProcess != null)
            {
                pHandle = MemoryReader.OpenProcess(MemoryReader.PROCESS_ALL_ACCESS, true, mhProcess.Id);

                //find monsters
                var game = new Game(pHandle);

                //hook events

                //to be background process to run every x time
                GameDataScanner.Start();
                var currentMonsters = game.Monsters;

                //update overlay(?)
            }

        }
    }
}
