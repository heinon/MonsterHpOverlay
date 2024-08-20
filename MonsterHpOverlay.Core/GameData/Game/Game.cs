using MonsterHpOverlay.Core.GameData.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MonsterHpOverlay.Core.GameData.Game
{
    public class Game : GameData
    {
        public const long MONSTER_ADDRESS = 0x05121688;
        public const long BASE = 0x140000000;
        public static readonly int[] MONSTER_OFFSET = new int[] { 0x698, 0x0, 0x138, 0x0 };

        private readonly Dictionary<long, GameData> _monsters = new Dictionary<long, GameData>();

        public Game(IntPtr handle) : base(handle)
        {
            GameDataScanner.Add(this);
        }

        public Dictionary<long, GameData> Monsters { get { return _monsters; } }

        public override void ScanData()
        {
            GetMonsters();
        }

        public void GetMonsters()
        {
            long monsterAddress = Memory.Read(BASE + MONSTER_ADDRESS, MONSTER_OFFSET);
            long currentMonster = monsterAddress;
            int count = 0;
            do
            {
                var monster = new Monster(Handle, currentMonster);
                if (monster != null)
                {
                    if (!_monsters.ContainsKey(currentMonster))
                    {
                        _monsters.Add(currentMonster, monster);
                        GameDataScanner.Add(monster);
                    }
                }

                currentMonster = Memory.Read<long>(currentMonster - 0x30) + 0x40;
                count++;
            } while (count < 3);
        }
    }
}
