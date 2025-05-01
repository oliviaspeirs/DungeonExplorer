using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents an abstract base class for all creatures in the game world.
    /// Provides basic properties and behaviors such as health, taking damage, attacking, and healing.
    /// </summary>
    public abstract class Creature : IDamageable
    {
        public int Health { get; set; } /// Gets or sets the creature's current health.

        public Creature(int health)
        {
            Health = health;
        }

        /// <summary>
        /// Causes the creature to take a specified amount of damage.
        /// Must be implemented by derived classes.
        /// </summary>
        /// <param name="amount">The amount of damage to inflict.</param>
        public abstract void TakeDamage(int amount);


        /// <summary>
        /// Makes the creature attack another creature.
        /// Must be implemented by derived classes.
        /// </summary>
        /// <param name="target">The target creature being attacked.</param>
        public abstract void Attack(Creature target);


        /// <summary>
        /// Heals the creature by a specified amount.
        /// </summary>
        /// <param name="amount">The amount of health to restore.</param>
        public virtual void Heal(int amount)
        {
            Health += amount;
            if (Health > 100) Health = 100;  /// Ensure health doesn't exceed 100
        }

        
    }
}
