using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Creature : IDamageable
    {
        public int Health { get; set; }

        public Creature(int health)
        {
            Health = health;
        }

        public abstract void TakeDamage(int amount);

        public abstract void Attack(Creature target);

        public virtual void Heal(int amount)
        {
            Health += amount;
            if (Health > 100) Health = 100;  // Ensure health doesn't exceed 100
        }

        
    }
}
