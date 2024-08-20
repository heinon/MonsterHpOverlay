using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHpOverlay.Integration.Manager
{
    public class MonsterZoneManager
    {
        public const long MONSTER_ADDRESS = 0x05121688;
        public const long BASE = 0x140000000;
        public static readonly int[] MONSTER_OFFSET = new int[] { 0x698, 0x0, 0x138, 0x0 };
    }
}
