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

        public Game()
        {
            // Initialize the game with one room and one player
            player = new Player("", 0, new List<string>());
            currentRooms = 0;
        }

        public void PlayersGo()
        {
            Console.WriteLine("Do you wish to go left, right or forward?");
            string decision = Console.ReadLine();

            Room nextRoom;

            switch (decision)
            {
                case "forward":
                case "left":
                case "right":
                    nextRoom = Room.GetRandomRoom();
                    break;
                default:
                    Console.WriteLine("Invalid input, try again");
                    return;
            }
            nextRoom.GetDescription(player, ref currentRooms);
        }

        public void Start()
        {
            // Change the playing logic into true and populate the while loop
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

                Console.WriteLine("Your goal: escape the dungeon. \nAlong your journey you will enter a series of rooms. \nSome may be empty but some may contain a monster. \nIn those rooms you will be attacked and will take damage. \nStay Safe!");

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
                }
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