using System;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    public class Room
    {
        // <summary>
        // Room attributes
        // Defines the different types of rooms
        // </summary>
        private static Random rnd = new Random();
        public const string empty = "empty";
        public const string SmallMonster = "SmallMonster";
        public const string BigMonster = "BigMonster";

        // <summary>
        // Room accessor
        // Gets the room type
        // </summary>
        public string RoomType { get; }

        // <summary>
        // Room constructor
        // Initialises a new instance of Room
        // </summary>
        // <param name="roomType"> Type of room. </param>
        public Room(string roomType)
        {
            RoomType = roomType;
        }

        // <summary>
        // Generates a random room
        // </summary>
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
                    return new Room(SmallMonster);
            }
        }

        // <summary>
        // A short description is assigned to each room type
        // Details whether there is a monster in the room or not
        // Also details whether player takes damage or not
        // and takes that damage away from players health
        // </summary>
        // <param name="player"> Players object. </param>
        // <param name="currentRooms"> A reference to current number of rooms entered. </param>
        public void GetDescription(Creature player, ref int currentRooms)
        {
            switch (RoomType)
            {
                case empty:
                    Console.WriteLine("The room is empty, you are safe and can move onto the next room!");
                    currentRooms++; // Adds 1 to current rooms
                    break;
                case SmallMonster:
                    Monster small = new SmallMonster();
                    int smalldamage = rnd.Next(10, 21);
                    player.TakeDamage(smalldamage);
                    Console.WriteLine($"You encounter a {small.Type}, you take {smalldamage} damage");
                    currentRooms++; // Adds 1 to current rooms
                    break;
                case BigMonster:
                    Monster big = new BigMonster();
                    int bigdamage = rnd.Next(21, 31);
                    player.TakeDamage(bigdamage);
                    Console.WriteLine($"You encounter a {big.Type}, you take {bigdamage} damage");
                    currentRooms++; // Adds 1 to current rooms
                    break;
                default:
                    Console.WriteLine("error occured");
                    break;

            }
        }

    }
}