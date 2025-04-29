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
        private List<Item>_inventory;

        public Inventory()
        {
            _inventory = new List<Item>(); 
        }

       

        // <summary>
        // Adds an item to the players inventory
        // </summary>
        // <param name="item"> Name of item being added to inventory. </param>
        public void PickUpItem(Item item)
        {
            _inventory.Add(item);
        }

        // <summary>
        // Checks if a certain item is in the players inventory
        // </summary>
        // <param name="itemname"> Name of item you want to check you have. </param>
        public bool CheckInventory(string itemName)
        {
            return _inventory.Any(i => i.ItemName == itemName);
        }


        // <summary>
        // Joins the inventory list into a string and returns it
        // Adds an item to the players inventory
        // </summary>
        public string InventoryContents()
        {
            return _inventory.Count > 0 ? string.Join(", ", _inventory.Select(i => i.ItemName)) : "Inventory is empty.";
        }

        // <summary>
        // Gets and sets the players inventory
        // </summary>
        public List<Item> Items
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public Item GetItemName(string itemName)
        {
            foreach (var item in _inventory)
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
            var item = GetItemName(itemName);
            if (item != null)
            {
                _inventory.Remove(item);
            }
        }

    }
}

