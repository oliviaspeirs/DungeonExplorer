using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        // Player attributes
        //Players Name, Health and inventory
        private string _name;
        private int _health;
        private List<string> _inventory;

        // Player constructors
        public Player(string name, int health, List<string> inventory) 
        {
            _name = name;
            _health = health;
            _inventory = inventory;
        }

        // Player accessors
        // Gets and sets values for the players name
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

        // Sets the players health value and if it dips below 0 or over 100 it just sets it to 0
        public int Health
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
        }


        // Gets and sets the players inventory
        public List<string> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        // Adds an item to the players inventory
        public void PickUpItem(string item)
        {
            _inventory.Add(item);
        }

        // Joins the inventory list into a string and returns it
        public string InventoryContents()
        {
            return string.Join(", ", _inventory);
        }

        // Checks if a certain item is in the players inventory
        public bool CheckInventory(string item)
        {
            return _inventory.Contains(item);
        }
    }
}