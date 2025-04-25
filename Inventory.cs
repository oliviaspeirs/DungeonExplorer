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
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>(); 
        }

       

        // <summary>
        // Adds an item to the players inventory
        // </summary>
        // <param name="item"> Name of item being added to inventory. </param>
        public void PickUpItem(Item item)
        {
            _items.Add(item);
        }

        // <summary>
        // Checks if a certain item is in the players inventory
        // </summary>
        // <param name="itemname"> Name of item you want to check you have. </param>
        public bool CheckInventory(string itemName)
        {
            return _items.Any(i => i.ItemName == itemName);
        }


        // <summary>
        // Joins the inventory list into a string and returns it
        // Adds an item to the players inventory
        // </summary>
        public string InventoryContents()
        {
            return _items.Count > 0 ? string.Join(", ", _items.Select(i => i.ItemName)) : "Inventory is empty.";
        }

        // <summary>
        // Gets and sets the players inventory
        // </summary>
        public List<string> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public Item GetItemName(string itemName)
        {
            foreach (var item in _items)
            {
                if (item.ItemName == itemName)
                {
                    return item;
                }
            }
            return null;  // Return null if no match is found
        }

        public void RemoveItem(string itemName)
        {
            var item = GetItemByName(itemName);
            if (item != null)
            {
                _items.Remove(item);
            }
        }

    }
}

