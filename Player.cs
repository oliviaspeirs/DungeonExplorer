using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        // player attributes
        private string _name;
        private int _health;
        private List<string> _inventory;

        // player constructors
        public Player(string name, int health, List<string> inventory) 
        {
            _name = name;
            _health = health;
            _inventory = inventory;
        }

        //player accessors
        public string Name
        {
            get { return _name; }
            set { 
                    if (string.IsNullOrEmpty(value))
                    {
                        Console.WriteLine("Inavlid input, name set to default player name:");
                        _name = "defaultPlayer";
                    }
                    else
                    {
                        _name = value;
                    }
                }
        }

        public int Health
        {
            get { return _health; }
            set {
                    if (value < 1)
                    {
                        _health = 0;
                    }
                    else
                    {
                        _health = value;
                    }
                }
        }

        public List<string> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public void PickUpItem(string item)
        {
            _inventory.Add(item);
        }
        public string InventoryContents()
        {
            return string.Join(", ", _inventory);
        }
    }
}