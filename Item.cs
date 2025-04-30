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

        public Item(string itemName)
        {
            ItemName = itemName;
        }

        // All items should be usable by a player
        public abstract void Use(Player player);

        public override string ToString()
        {
            return ItemName;
        }

    }

    public class Weapon : Item
    {
        public int DamageValue { get; set; }
        public int HitChance { get; set; }
        public Weapon(string name, int damageValue, int hitChance) : base(name)
        {
            
            DamageValue = damageValue;
            HitChance = hitChance;
        }
        public override void Use(Player player)
        {
            Console.WriteLine($"{player.Name} has equipped the {ItemName}.");
        }
    }

    public class Sword : Weapon
    {
        public Sword() : base("SW", 150, 80)
        {
        }
    }

    public class SmallHealthPotion : Item
    {
        public SmallHealthPotion() : base("S")
        {
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
        public RegularHealthPotion() : base("R")
        {
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

