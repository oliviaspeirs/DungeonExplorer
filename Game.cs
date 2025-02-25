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
            Player player = new Player("", 0);
            currentRooms = 0;
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                // Code your playing logic here
                Console.WriteLine("Enter your name:");
                string playerName = Console.ReadLine();
                player.Name = playerName;
                player.Health = 100;
                Console.WriteLine($"Player creation successful, hello {player.Name} you are at {player.Health} health.");

                
            }
        }
    }
}