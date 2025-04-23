using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Creature
    {
        public int Health { get; set; }

        public Creature(int health)
        {
            Health = health;
        }

        public abstract void TakeDamage(int amount);
    }
}
