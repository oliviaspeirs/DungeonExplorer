using System;
using System.Collections.Generic;

namespace DungeonExplorer
{

    /// <summary>
    /// Represents the player character.
    /// Inherits from <see cref="Creature"/> and includes position, inventory, and combat capabilities.
    /// </summary>
    public class Player : Creature
    {

        public int X { get; set; } /// Gets or sets Player’s horizontal position on the map
        public int Y { get; set; } /// Gets or sets Player’s vertical position on the map


        // <summary>
        // Player attributes
        // Players Name and inventory
        // </summary>
        private string _name;
        private Inventory _inventory; /// creates an instance of the inventory class
        public Weapon equippedWeapon { get; set; } /// Gets or sets the weapon currently equipped by the player.

        public Inventory Inventory /// Gets the player's inventory.
        {
            get { return _inventory; }
        }



        // <summary>
        // Player constructors
        // </summary>
        // <param name="name"> Players name. </param>
        // <param name="health"> Players initial health. </param>
        /// <param name="inventory">The player's inventory (a new one will be created if null).</param>
        public Player(string name, int health, Inventory inventory) : base(health)
        {
            _name = name;
            X = 0;
            Y = 0;
            _inventory = inventory ?? new Inventory();
            equippedWeapon = null;
        }

        /// <summary>
        /// Override the TakeDamage method from Creature class
        /// </summary>
        /// <param name="amount">The amount of damage to take.</param>
        public override void TakeDamage(int amount)
        {
            Health -= amount; /// Reduces the player's health by the specified damage amount.
            if (Health < 0) Health = 0; /// Ensure health doesn't go below 0
        }

        /// <summary>
        /// Attacks the specified target creature using either an equipped weapon or a default chance-based method.
        /// </summary>
        /// <param name="target">The creature to attack.</param>
        public override void Attack(Creature target)
        {
            
            Random rnd = new Random();
            if (equippedWeapon != null) /// If they have a weapon equipped then atttacksuccess = hit chance
            {
                int attacksuccess = equippedWeapon.HitChance;
                target.TakeDamage(equippedWeapon.DamageValue); // Deals whatever damage that weapon deals
                Console.WriteLine("You attack and manage to defeat this monster!");
                target.Health = 0;
            }
            else
            {
                int attacksuccess = rnd.Next(1, 101); /// Generates a number between 1 and 100
                if (attacksuccess > 50)
                {
                    target.TakeDamage(100); /// Kills small monsters
                    if (target.Health > 0) // If its a big monster
                    {

                        int attacksuccessBig = rnd.Next(1, 101); /// Generates a number between 1 and 100
                        if (attacksuccessBig > 75)
                        {
                            Console.WriteLine("You attack and manage to defeat this monster!");
                            target.Health = 0;
                        }
                        else
                        {
                            Console.WriteLine("You attack but do not manage to defeat this monster.");
                            target.Health += 100;
                        }

                    }
                    else
                    {
                        Console.WriteLine("You attack and manage to defeat this monster!");
                        target.Health = 0;
                    }
                }
                else
                {
                    Console.WriteLine("You attack but do not manage to defeat this monster.");
                    target.TakeDamage(0);
                }
            }
            
            
        }


        // <summary>
        // Player accessors
        // Gets and sets values for the players name
        // </summary>
        public string Name
        {
            get { return _name; }
            set { 
                    if (string.IsNullOrEmpty(value)) /// If player input is empty
                    {
                        Console.WriteLine("Inavlid input, name set to default player name:");
                        _name = "defaultPlayer"; /// Defaults the name to "defaultPlayer""
                    }
                    else
                    {
                        _name = value;
                    }
                }
        }

    }
}