using System;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    public class Room
    {
        /// <summary>
        /// Room attributes
        /// Defines the different types of rooms
        /// </summary>
        private static Random rnd = new Random();
        public const string empty = "empty";
        public const string SmallMonster = "SmallMonster";
        public const string BigMonster = "BigMonster";

        /// <summary>
        /// Room accessor
        /// Gets the room type
        /// </summary>
        public string RoomType { get; set; }

        /// Tracks if the monster has been defeated
        public bool MonsterDefeated { get; private set; }

        /// <summary>
        /// Room constructor
        /// Initialises a new instance of Room
        /// </summary>
        /// <param name="roomType"> Type of room. </param>
        public Room(string roomType)
        {
            RoomType = roomType;
            MonsterDefeated = false;
        }

        /// <summary>
        /// Generates a random room
        /// </summary>
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

        /// <summary>
        /// A short description is assigned to each room type
        /// Details whether there is a monster in the room or not
        /// Also details whether player takes damage or not
        /// and takes that damage away from players health
        /// </summary>
        /// <param name="player"> Players object. </param>
        /// <param name="currentRooms"> A reference to current number of rooms entered. </param>
        public void GetDescription(Creature player, ref int currentRooms)
        {
            Monster monster = null;
            
            /// <summary> 
            /// Checks to see if a monster was defeated in this room.
            /// </summary>
            if (MonsterDefeated)
            {
                Console.WriteLine("This room has already been cleared. There is no monster here.");
                currentRooms++; /// Proceed to the next room without any monster encounter
                return; /// Skip the encounter since the monster is defeated
            }

            switch (RoomType)
            {
                case empty:
                    Console.WriteLine("The room is empty, you are safe and can move onto the next room!");
                    break;
                case SmallMonster:
                    monster = new SmallMonster();
                    break;
                case BigMonster:
                    monster = new BigMonster();
                    break;
                default:
                    Console.WriteLine("error occured");
                    break;

            }

            if (monster != null)
            {
                /// Monster attacks the player
                monster.Attack(player); // Calls the Attack method of the specific monster (SmallMonster or BigMonster)

                /// If player is still alive, the player can retaliate
                if (player.Health > 0)
                {
                    player.Attack(monster); /// The player attacks the monster, and this will invoke the player's Attack method
                    if (monster.Health == 0)
                    {
                        MonsterDefeated = true;
                        RoomType = empty;
                    }
                    else
                    {
                        MonsterDefeated = false;
                    }

                }
            }

            currentRooms++; /// Proceed to the next room

        }

    }
}