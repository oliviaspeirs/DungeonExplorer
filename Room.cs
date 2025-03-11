using System;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    public class Room
    {
        // Room attributes
        // Defines the different types of rooms
        private static Random rnd = new Random();
        public const string empty = "empty";
        public const string SmallMonster = "SmallMonster";
        public const string BigMonster = "BigMonster";
        
        // Room accessor
        // Gets the room type
        public string RoomType { get; }

        // Room constructor
        // Initialises a new instance of Room
        public Room(string roomType)
        {
            RoomType = roomType;
        }

        // Generates a random room
        public static Room GetRandomRoom()
        {
            int randomNumber = rnd.Next(1, 4);
            switch (randomNumber)
            {
                case 1:
                    return new Room(empty);
                case 2:
                    return new Room(SmallMonster);
                case 3:
                    return new Room(BigMonster);
                default:
                    return new Room(empty);
            }
        }

        // A short description is assigned to each room type
        // Details whether there is a monster in the room or not
        // Also details whether player takes damage or not
        // and takes that damage away from players health
        public void GetDescription(Player player, ref int currentRooms)
        {
            switch (RoomType)
            {
                case empty:
                    Console.WriteLine("The room is empty, you are safe and can move onto the next room!");
                    currentRooms++; // Adds 1 to current rooms
                    break;
                case SmallMonster:
                    int damage = rnd.Next(10, 21);
                    player.Health -= damage;
                    Console.WriteLine($"You encounter a small monster, you take {damage} damage");
                    currentRooms++; // Adds 1 to current rooms
                    break;
                case BigMonster:
                    damage = rnd.Next(21, 31);
                    player.Health -= damage;
                    Console.WriteLine($"You encounter a big monster, you take {damage} damage");
                    currentRooms++; // Adds 1 to current rooms
                    break;
                default:
                    Console.WriteLine("error occured");
                    break;

            }
        }

    }
}