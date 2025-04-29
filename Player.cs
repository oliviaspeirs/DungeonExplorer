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
        }



        // <summary>
        // Player constructors
        // </summary>
        // <param name="name"> Players name. </param>
        // <param name="health"> Players initial health. </param>
        public Player(string name, int health, Inventory inventory) : base(health)
        {
            _name = name;
            X = 0;
            Y = 0;
            _inventory = inventory ?? new Inventory();
        }


        public override void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0; // Ensure health doesn't go below 0
        }

        public override void Attack(Creature target)
        {
            // Random damage between 10 and 20
            Random rnd = new Random();
            int attacksuccess = rnd.Next(1, 101); // Generates a number between 10 and 20
            if (attacksuccess > 50)
            {
                target.TakeDamage(100);
                if (target.Health > 0) //If its a big monster
                {
                    int attacksuccessBig = rnd.Next(1, 101);
                    if (attacksuccessBig > 75) 
                    {
                        Console.WriteLine("You attack and manage to defeat this monster!");
                        target.Health = 0;
                    }
                    else {
                        Console.WriteLine("You attack but do not manage to defeat this monster.");
                        target.Health += 100;
                    }
                    
                }
                else
                {
                    Console.WriteLine("You attack and manage to defeat this monster!");
                    target.Health = 0;
                }
            }
            else
            {
                Console.WriteLine("You attack but do not manage to defeat this monster.");
                target.TakeDamage(0);
            }
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