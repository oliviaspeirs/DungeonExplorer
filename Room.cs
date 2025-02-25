using System;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    public class Room
    {
        private static Random rnd = new Random()
        public string empty = "empty";
        public string SmallMonster = "SmallMonster";
        public string BigMonster = "BigMonster";
        
        private string description;

        public static Room GetRandomRoom()
        {
            int randomNumber = _random.Next(1, 4);
            if (randomNumber == 1)
            {
                return Room(empty);
            }else if (randomNumber == 2)
            {
                return Room(SmallMonster)
            }else (randomNumber == 3)
            {
                return Room(BigMonster)
            }
        }

        public Room(string description)
        {
            this.description = description;
        }

        public void GetDescription(Player player, ref int currentRoom)
        {
            switch (description)
            {
                case empty:
                    Console.WriteLine("The room is empty, you are safe!")
                    currentRooms++;
                    break;
                case SmallMonster:
                    int damage = rnd.Next(1,11)
                    player.Health -= damage;
                    Console.WriteLine("You encounter a small monster, you take some damage")
                    currentRooms++;
                    break;
                case BigMonster:
                    damage = rnd.Next(11,21)
                        player.Health -= damage;
                    Console.WriteLine("You encounter a big monster, you take lots of damage")
                    currentRooms++;
                    break;
                default:
                    Console.WriteLine("error occured")
                    break;

            }
        }
    }
}