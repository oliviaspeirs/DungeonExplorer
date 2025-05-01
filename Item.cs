using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents an item that can be used by a player.
    /// </summary>
    public abstract class Item : IUsable
    {
        /// <summary>
        /// Gets the name of the item.
        /// </summary>
        public string ItemName { get; protected set; }


        /// <summary>
        /// Initializes a new instance of the Item class.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        public Item(string itemName)
        {
            ItemName = itemName;
        }

        /// <summary>
        /// Uses the item on the specified player.
        /// </summary>
        /// <param name="player">The player using the item.</param>
        public abstract void Use(Player player);

        public override string ToString() /// Returns a string that represents the current item.
        {
            return ItemName;
        }

    }


    /// <summary>
    /// Represents a weapon item that can deal damage.
    /// Gets or sets the damage value and hit chance of the weapon.
    /// </summary>
    public class Weapon : Item
    {
        public int DamageValue { get; set; }
        public int HitChance { get; set; }
        public Weapon(string name, int damageValue, int hitChance) : base(name)
        {
            
            DamageValue = damageValue;
            HitChance = hitChance;
        }

        public override void Use(Player player) /// Equips the weapon to the player.
        {
            Console.WriteLine($"{player.Name} has equipped the {ItemName}.");
        }
    }


    /// <summary>
    /// Represents a specific type of weapon: a sword.
    /// </summary>
    public class Sword : Weapon
    {
        public Sword() : base("SW", 150, 80)
        {
        }
    }


    /// <summary>
    /// Represents a small health potion item.
    /// </summary>
    public class SmallHealthPotion : Item
    {
        public SmallHealthPotion() : base("S")
        {
        }

        /// <summary>
        /// Heals the player by a small amount if their health is low enough.
        /// </summary>
        /// <param name="player">The player using the potion.</param>
        public override void Use(Player player)
        {
            if (player.Health >= 90)
            {
                Console.WriteLine("Your health is too high to use this potion.");
            }
            else
            {
                player.Heal(10);
                Console.WriteLine($"You have gained 10 health. You are now at {player.Health} health.");
            }
        }
    }


    /// <summary>
    /// Represents a regular health potion item.
    /// </summary>
    public class RegularHealthPotion : Item
    {
        public RegularHealthPotion() : base("R")
        {
        }

        /// <summary>
        /// Heals the player by a moderate amount if their health is low enough.
        /// </summary>
        /// <param name="player">The player using the potion.</param>
        public override void Use(Player player)
        {
            if (player.Health >= 80)
            {
                Console.WriteLine("Your health is too high to use this potion.");
            }
            else
            {
                player.Heal(20);
                Console.WriteLine($"You have gained 20 health. You are now at {player.Health} health.");
            }
        }
    }

}

