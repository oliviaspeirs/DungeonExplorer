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
        //private int _health;
        private List<string> _inventory;

        // <summary>
        // Player constructors
        // </summary>
        // <param name="name"> Players name. </param>
        // <param name="health"> Players initial health. </param>
        // <param name="inventory"> Players initial inventory. </param>
        public Player(string name, int health, List<string> inventory) : base(health)
        {
            _name = name;
            _inventory = inventory;
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

        // <summary>
        // Sets the players health value and if it dips below 0 or over 100 it just sets it to 0
        // </summary>
       /* public int Health
        {
            get { return _health; }
            set {
                    if (value < 1 || value > 100)
                    {
                        _health = 0;
                    }
                    else
                    {
                        _health = value;
                    }
                }
        }*/

        // <summary>
        // Gets and sets the players inventory
        // </summary>
        public List<string> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        // <summary>
        // Adds an item to the players inventory
        // </summary>
        // <param name="item"> Name of item being added to inventory. </param>
        public void PickUpItem(string item)
        {
            _inventory.Add(item);
        }

        // <summary>
        // Joins the inventory list into a string and returns it
        // Adds an item to the players inventory
        // </summary>
        public string InventoryContents()
        {
            return string.Join(", ", _inventory);
        }

        // <summary>
        // Checks if a certain item is in the players inventory
        // </summary>
        // <param name="item"> Name of item you want to check you have. </param>
        public bool CheckInventory(string item)
        {
            return _inventory.Contains(item);
        }
    }
}