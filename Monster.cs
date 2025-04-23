using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Monster : Creature
    {
        public string Type { get; set; }  // The type of monster, e.g., "SmallMonster" or "BigMonster"

        // Constructor for Monster
        public Monster(string type, int health) : base(health)
        {
            Type = type;
        }

        
        

    }

    public class SmallMonster : Monster
    {
        public SmallMonster() : base("SmallMonster", 25) { } // name and health of small monster

        // Override the TakeDamage method from Creature class
        public override void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"The Big monster has taken {amount} damage.");
            if (Health < 0) Health = 0; // Ensure health doesn't go below 0
        }
    }

    public class BigMonster : Monster
    {
        public BigMonster() : base("BigMonster", 50) { }

        public override void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"The Big monster has taken {amount} damage.");
            if (Health < 0) Health = 0; // Ensure health doesn't go below 0
        }
    }
}
