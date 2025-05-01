using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{

    /// <summary>
    /// Represents an abstract base class for all monster types.
    /// Inherits from the <see cref="Creature"/> class and adds a type descriptor.
    /// </summary>
    public abstract class Monster : Creature
    {
        public string Type { get; set; }  /// Gets or sets the type of monster, e.g., "SmallMonster" or "BigMonster"

        /// Constructor for Monster
        public Monster(string type, int health) : base(health)
        {
            Type = type;
            Health = health;
        } 

    }


    /// <summary>
    /// Represents a small monster with standard health and damage.
    /// Initializes a new instance of the <see cref="SmallMonster"/> class with default values.
    /// </summary>
    public class SmallMonster : Monster
    {
        public SmallMonster() : base("SmallMonster", 100) { } // name and health of small monster

        /// <summary>
        /// Override the TakeDamage method from Creature class
        /// </summary>
        /// <param name="amount">The amount of damage to take.</param>
        public override void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0; /// Ensure health doesn't go below 0
        }

        /// <summary>
        /// Override the Attack method from Creature class
        /// Attacks a target creature with randomly determined damage.
        /// </summary>
        /// <param name="target">The target creature to attack.</param>
        public override void Attack(Creature target)
        {
            
            Random rnd = new Random();
            int damage = rnd.Next(10, 21); /// Generates a number between 10 and 20
            Console.WriteLine($"Oh no, a small monster! you take {damage} damage!");

            /// Apply damage to the target (the player)
            target.TakeDamage(damage);
        }


    }

    /// <summary>
    /// Represents a big monster with higher health and more damage potential.
    /// Initializes a new instance of the <see cref="BigMonster"/> class with default values.
    /// </summary>
    public class BigMonster : Monster
    {
        public BigMonster() : base("BigMonster", 150) { }


        /// <summary>
        /// Override the TakeDamage method from Creature class
        /// </summary>
        /// <param name="amount">The amount of damage to take.</param>
        public override void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0; // Ensure health doesn't go below 0
        }


        /// <summary>
        /// Override the Attack method from Creature class
        /// Attacks a target creature with randomly determined damage.
        /// </summary>
        /// <param name="target">The target creature to attack.</param>
        public override void Attack(Creature target)
        {
            
            Random rnd = new Random();
            int damage = rnd.Next(20, 31); /// Generates a number between 20 and 30
            Console.WriteLine($"Oh no, a big monster! you take {damage} damage!");

            /// Apply damage to the target (the player)
            target.TakeDamage(damage);
        }
    }
}
