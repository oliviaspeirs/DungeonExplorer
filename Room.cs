using System;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    public class Room
    {
        private static Random rnd = new Random()
        public string empty;
        public string SmallMonster;
        public string BigMonster;
        
        private string description;

        public static GetRandomRoom()
        {
            int randomNumber = _random.Next(1, 3);
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

        public string GetDescription()
        {
            return description;
        }
    }
}