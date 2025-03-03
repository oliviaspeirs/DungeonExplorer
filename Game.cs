using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private int currentRooms;

        public Game()
        {
            // Initialize the game with one room and one player
            Player player = new Player("", 0, new List<string>();
            currentRooms = 0;
        }

        public void PlayersGo()
        {
            Console.WriteLine("Do you wish to go left, right or forward?")
            string decision = Console.ReadLine();

            Room nextRoom

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
                player.Inventory = new System.Collections.Generic.List<string>();
                Console.WriteLine($"Player creation successful, hello {player.Name} you are at {player.Health} health.");
                Console.WriteLine("To start game press any key");
                Console.ReadKey();

                Console.WriteLine("Your goal: escape the dungeon. \nAlong your journey you will enter a serious of rooms. \nSome may be empty but some may contain a monster, in those rooms damage can be taken");

                playing = false;
                while (currentRooms < 5 && player.Health > 0)
                {
                    
                }
            }
        }
    }
}