using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        private string _name 
        private int _health 
        private List<string> _inventory = new List<string>();

        public Player(string name, int health) 
        {
            _name = name;
            _health = health;
        }

        public string Name
        {
            get { return _name; }
            set { 
                    if (string.IsNullOrEmpty(value))
                    {
                        Console.WriteLine("Inavlid input, name set to default player name:")
                        _name = "defaultPlayer"
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

        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}