using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHpOverlay.Core.GameData
{
    public class GameData
    {
        private Memory _memory;
        private IntPtr _handle;

        public GameData(IntPtr handle)
        {
            _memory = new Memory(handle);
            _handle = handle;
        }

        public Memory Memory { get { return _memory; } }
        public IntPtr Handle { get { return _handle; } }

        public virtual void ScanData()
        {

        }
    }

}
