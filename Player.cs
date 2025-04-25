using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player : Creature
    {

        public int X { get; set; } // Player’s horizontal position on the map
        public int Y { get; set; } // Player’s vertical position on the map


        // <summary>
        // Player attributes
        // Players Name and inventory
        // </summary>
        private string _name;
        private Inventory _inventory; // creates an instance of the inventory class

        public Inventory Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }


        // <summary>
        // Player constructors
        // </summary>
        // <param name="name"> Players name. </param>
        // <param name="health"> Players initial health. </param>
        // <param name="inventory"> Players initial inventory. </param>
        public Player(string name, int health, List<string> items) : base(health)
        {
            _name = name;
            _inventory = new Inventory (items);
            X = 0;
            Y = 0;

        }

        public override void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0; // Ensure health doesn't go below 0
        }

        // <summary>
        // Player accessors
        // Gets and sets values for the players name
        // </summary>
        public string Name
        {
            get { return _name; }
            set { 
                    if (string.IsNullOrEmpty(value)) // If player input is empty
                    {
                        Console.WriteLine("Inavlid input, name set to default player name:");
                        _name = "defaultPlayer"; // Defaults the name to "defaultPlayer""
                    }
                    else
                    {
                        _name = value;
                    }
                }
        }

    }
}