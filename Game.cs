using System;
using System.Collections.Generic;
using System.Media;
using System.Security.Authentication;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private int currentRooms;
        private static Random rnd = new Random();

        public Game()
        {
            // Creates a new player and a way of keeping track of rooms entered
            player = new Player("", 0, new List<string>());
            currentRooms = 0;
        }

        // function that allows player to choose a direction
        // this function calls the GetRandomRoom and GetDescription functions to provide
        // a  room for the player to enter 
        public void PlayersGo()
        {
            Console.WriteLine("Do you wish to go left, right or forward?");
            string decision = Console.ReadLine();

            Room nextRoom;

            switch (decision)
            {
                case "forward":
                    nextRoom = Room.GetRandomRoom();
                    itemCheck();
                    break;
                case "left":
                    nextRoom = Room.GetRandomRoom();
                    itemCheck();
                    break;
                case "right":
                    nextRoom = Room.GetRandomRoom();
                    itemCheck();
                    break;
                default:
                    Console.WriteLine("Invalid input, try again");
                    return;
            }
            nextRoom.GetDescription(player, ref currentRooms);
        }

        // randomly decides whether a room contains an item
        public void itemCheck()
        {

            int randomNumber = rnd.Next(1, 4);
            switch (randomNumber)
            {
                case 1:
                    Console.WriteLine("You've picked up a small health potion (S). \nYou can use this at the beginning of your turns.");
                    player.PickUpItem("S");
                    break;
                case 2:
                    Console.WriteLine("You've picked up a regular health potion (R). \nYou can use this at the beginning of your turns.");
                    player.PickUpItem("R");
                    break;
                case 3:
                    break;

            }
        }

        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                // player set up
                Console.WriteLine("Enter your name:");
                string playerName = Console.ReadLine();
                player.Name = playerName;
                player.Health = 100;
                player.Inventory = new List<string>();
                Console.WriteLine($"Player creation successful, hello {player.Name} you are at {player.Health} health.");
                Console.WriteLine("To start game press any key");
                Console.ReadKey();

                // game explanation
                Console.WriteLine("Your goal: escape the dungeon. \nAlong your journey you will enter a series of rooms. \nSome may be empty but some may contain a monster. \nIn those rooms you will be attacked and will take damage. \nStay Safe!");

                // start of actual game loop
                playing = false;
                while (currentRooms < 5 && player.Health > 0)
                {
                    PlayersGo();
                    Console.WriteLine("Do you wish to see your stats? y/n");
                    string statsAnswer = Console.ReadLine();
                    switch (statsAnswer)
                    {
                        case "y":
                            Console.WriteLine($"your health is {player.Health} \nand you have been in {currentRooms} rooms");
                            break;
                        case "n":
                            break;
                        default:
                            Console.WriteLine("Press any key to continue the game.");
                            Console.ReadKey();
                            break;
                    }
                    Console.WriteLine("Do you wish to see your inventory? y/n");
                    string inventoryAnswer = Console.ReadLine();
                    switch (inventoryAnswer)
                    {
                        case "y":
                            Console.WriteLine(player.InventoryContents());
                            break;
                        case "n":
                            break;
                        default:
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;
                    }
                }
                // when the game ends it determines whether you escaped or not based on your health
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