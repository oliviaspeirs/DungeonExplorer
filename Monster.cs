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
        public SmallMonster() : base("SmallMonster", 100) { } // name and health of small monster

        // Override the TakeDamage method from Creature class
        public override void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0; // Ensure health doesn't go below 0
        }

        public override void Attack(Creature target)
        {
            // Random damage between 10 and 20
            Random rnd = new Random();
            int damage = rnd.Next(10, 21); // Generates a number between 10 and 20
            Console.WriteLine($"Oh no, a small monster! you take {damage} damage!");

            // Apply damage to the target (the player)
            target.TakeDamage(damage);
        }


    }

    public class BigMonster : Monster
    {
        public BigMonster() : base("BigMonster", 150) { }

        public override void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0; // Ensure health doesn't go below 0
        }

        public override void Attack(Creature target)
        {
            // Random damage between 10 and 20
            Random rnd = new Random();
            int damage = rnd.Next(20, 31); // Generates a number between 10 and 20
            Console.WriteLine($"Oh no, a big monster! you take {damage} damage!");

            // Apply damage to the target (the player)
            target.TakeDamage(damage);
        }
    }
}
