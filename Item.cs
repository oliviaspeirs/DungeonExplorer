using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Item : IUsable
    {
    
        public string ItemName { get; protected set; }

        // All items should be usable by a player
        public abstract void Use(Player player);

        public override string ToString()
        {
            return ItemName;
        }

    }

    public class SmallHealthPotion : Item
    {
        public SmallHealthPotion()
        {
            ItemName = "S";
        }

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

    public class RegularHealthPotion : Item
    {
        public RegularHealthPotion()
        {
            ItemName = "R";
        }

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

