﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Media;
using System.Security.Authentication;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player; // Player object
        private int currentRooms; // number of rooms passed
        private static Random rnd = new Random();

        // <summary>
        // Defines the different items you can pick up
        // </summary>
        public const string SmallHealthPotion = "S";
        public const string RegularHealthPotion = "R";

        public Game()
        {
            // Creates a new player and defaults number of rooms passed to 0
            player = new Player("", 0, new List<string>());
            currentRooms = 0;
        }

        // <summary>
        // function that allows player to choose a direction
        // provides a random room for the player to enter 
        // </summary>
        public void PlayersGo()
        {
            Console.WriteLine("\nDo you wish to go left, right or forward?");
            string decision = Console.ReadLine().ToLower();

            Room nextRoom;

            // chooses the next room based on users choice of direction
            switch (decision)
            {
                case "forward":
                case "left":
                case "right":
                    nextRoom = Room.GetRandomRoom();
                    itemCheck();    
                    break;
                default:
                    Console.WriteLine("Invalid input, try again");
                    return;
            }
            nextRoom.GetDescription(player, ref currentRooms);
            viewStats();
            viewInventory();
            useItemChoice();
        }

        // <summary>
        // randomly decides whether a room contains an item
        // </summary>
        public void itemCheck()
        {

            int randomNumber = rnd.Next(1, 4);
            switch (randomNumber)
            {
                case 1:
                    Console.WriteLine("You've picked up a small health potion (S).");
                    player.PickUpItem(SmallHealthPotion); // adds item to inventory
                    break;
                case 2:
                    Console.WriteLine("You've picked up a regular health potion (R).");
                    player.PickUpItem(RegularHealthPotion); //adds item to inventory
                    break;
                case 3:
                    return;

            }
        }

        // <summary>
        // This function gives the player the choice whether or not to use an item
        // </summary>
        public void useItem()
        {
            Console.WriteLine("\nWhat item do you wish to use? S/R");
            string itemChoice = Console.ReadLine().ToUpper();

            // First if statement checks if the user input is actually in the inventory
            if (player.CheckInventory(itemChoice) == true)
            {
                // Second if statement checks whether the user typed "S" or "R"
                if (itemChoice == "S")
                {
                    // Third if statement checks if the player is damaged enough to use the item
                    // If they are, the designated amount of health is added
                    if (player.Health >= 95)
                    {
                        Console.WriteLine("Your health is too high to use this potion");
                    }
                    else
                    {
                        player.Health += 5;
                        Console.WriteLine($"You have gained 5 health, you are now at {player.Health} health.");
                        player.Inventory.Remove(itemChoice); 
                    }
                }
                else if (itemChoice == "R")
                {
                    if (player.Health >= 90)
                    {
                        Console.WriteLine("Your health is too high to use this potion");
                    }
                    else
                    {
                        player.Health += 10;
                        Console.WriteLine($"You have gained 10 health, you are now at {player.Health} health.");
                        player.Inventory.Remove(itemChoice);
                    }
                }

            }
            else
            {
                Console.WriteLine("You do not have that item in your inventory.");
            }
        }

        // <summary>
        // Gives the user the choice to view their stats
        // </summary>
        public void viewStats()
        {
            Console.WriteLine("\nView your stats? y/n");
            string statsAnswer = Console.ReadLine().ToLower();
            switch (statsAnswer)
            {
                case "y":
                    Console.WriteLine($"{player.Name}, your health is {player.Health} \nand you have been in {currentRooms} rooms");
                    break;
                case "n":
                    break;
                default:
                    Console.WriteLine("Invalid input, answer taken as no \nPress any key to continue the game.");
                    Console.ReadKey();
                    break;
            }
        }

        // <summary>
        // Gives the user the choice to view the items in their inventory
        // </summary>
        public void viewInventory()
        {
            Console.WriteLine("\nView your inventory? y/n");
            string inventoryAnswer = Console.ReadLine().ToLower();
            switch (inventoryAnswer)
            {
                case "y":
                    Console.WriteLine(player.InventoryContents());
                    break;
                case "n":
                    break;
                default:
                    Console.WriteLine("Invalid input, answer taken as no \nPress any key to continue.");
                    Console.ReadKey();
                    break;
            }
        }

        // <summary>
        // Gives the user the choice to use an item in their inventory
        // </summary>
        public void useItemChoice()
        {
            Console.WriteLine("\nAnd finally before you move on: \nDo you wish to use an item in your inventory? y/n");
            string itemAnswer = Console.ReadLine().ToLower();
            switch (itemAnswer)
            {
                case "y":
                    useItem(); // Lets user pick what item to use
                    break;
                case "n":
                    break;
                default:
                    Console.WriteLine("Invalid input, answer taken as no \nPress any key to continue.");
                    break;
            }
        }

        // <summary>
        // Starts the actual game play
        // </summary>
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                // Player set up
                // Asks for name and then provides default values for health and inventory
                Console.WriteLine("Enter your name:");
                string playerName = Console.ReadLine();
                player.Name = playerName;
                player.Health = 100;
                player.Inventory = new List<string>();

                Test PlayerTest = new Test(player);
                PlayerTest.PlayerTesting();

                Console.WriteLine($"Player creation successful, hello {player.Name} you are at {player.Health} health.");
                Console.WriteLine("To start game press any key");
                Console.ReadKey();

                // Game explanation
                Console.WriteLine("\nYour goal: escape the dungeon. " +
                    "\nAlong your journey you will enter a series of rooms. " +
                    "\nSome may be empty but some may contain a monster. " +
                    "\nIn those rooms you will be attacked and will take damage. " +
                    "\nYou may also occasionally obtain items. " +
                    "\nThese can be used at the beginning of each turn." +
                    $"\nStay Safe {player.Name}!");

                // start of actual game loop
                // loops until they escape the maze or their health drops to 0
                playing = false;
                while (currentRooms < 5 && player.Health > 0)
                {
                    PlayersGo();

                    
                }
                // when the game loop ends it determines whether you escaped or not based on your health
                if (player.Health <= 0)
                {
                    Console.WriteLine("You died");
                }
                else
                {
                    Console.WriteLine("You escaped the dungeon");
                }
            }
        }
    }
}