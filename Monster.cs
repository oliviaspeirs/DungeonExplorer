using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Monster : Creature
    {
        public string Type { get; set; }  // The type of monster, e.g., "SmallMonster" or "BigMonster"

        // Constructor for Monster
        public Monster(string type, int health) : base(health)
        {
            Type = type;
        }

        // Override the TakeDamage method from Creature class
        public override void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0; // Ensure health doesn't go below 0
        }

    }
}
