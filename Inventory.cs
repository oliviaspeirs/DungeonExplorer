using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Inventory
    {
        private List<string> _items;

        public Inventory()
        {
            _items = new List<string>();
        }

        public Inventory(List<string> items)
        {
            _items = items;
        }

        // <summary>
        // Adds an item to the players inventory
        // </summary>
        // <param name="item"> Name of item being added to inventory. </param>
        public void PickUpItem(string item)
        {
            _items.Add(item);
        }

        // <summary>
        // Checks if a certain item is in the players inventory
        // </summary>
        // <param name="item"> Name of item you want to check you have. </param>
        public bool CheckInventory(string item)
        {
            return _items.Contains(item);
        }

        // <summary>
        // Joins the inventory list into a string and returns it
        // Adds an item to the players inventory
        // </summary>
        public string InventoryContents()
        {
            return string.Join(", ", _items);
        }

        // <summary>
        // Gets and sets the players inventory
        // </summary>
        public List<string> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public void RemoveItem(string item)
        {
            _items.Remove(item);
        }

    }
}

