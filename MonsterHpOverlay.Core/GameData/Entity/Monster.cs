using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHpOverlay.Core.GameData.Entity
{
    public class Monster : GameData
    {
        private readonly long _monsterAddress;
        private float _health;
        public Monster(IntPtr handle, long monsterAddress) : base(handle)
        {
            _monsterAddress = monsterAddress;
        }

        public int Id { get; set; }
        public float Health
        {
            get => _health;
            set
            {
                if (value != _health)
                {
                    _health = value;
                    OnHealthChange.Invoke(this, EventArgs.Empty);

                    if(_health <= 0)
                    {
                        OnDeath.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }

        public float MaxHealth { get; set; }

        public event EventHandler OnHealthChange;

        public event EventHandler OnSpawn;

        public event EventHandler OnDeath;

        public override void ScanData()
        {
            GetHealth();
        }

        public void GetHealth()
        {
            long monsterHealthPtr = Memory.Read<long>(_monsterAddress + 0x7670);
            float[] healthValues = Memory.Read<float>(monsterHealthPtr + 0x60, 2);
            Health = healthValues[0];
            MaxHealth = healthValues[1];
        }
    }
}
