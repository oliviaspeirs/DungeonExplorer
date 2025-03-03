﻿using System;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    public class Room
    {
        // room attributes
        private static Random rnd = new Random();
        public string empty = "empty";
        public string SmallMonster = "SmallMonster";
        public string BigMonster = "BigMonster";
        
        //room accessor
        public string RoomType { get; }

        // room constructor
        public Room(string roomType)
        {
            RoomType = roomType;
        }

        private string description;

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

        public Room(string description)
        {
            this.description = description;
        }

        public void GetDescription(Player player, ref int currentRoom)
        {
            switch (RoomType)
            {
                case empty:
                    Console.WriteLine("The room is empty, you are safe!");
                    currentRooms++;
                    break;
                case SmallMonster:
                    int damage = rnd.Next(1, 11);
                    player.Health -= damage;
                    Console.WriteLine("You encounter a small monster, you take some damage");
                    currentRooms++;
                    break;
                case BigMonster:
                    damage = rnd.Next(11, 21);
                        player.Health -= damage;
                    Console.WriteLine("You encounter a big monster, you take lots of damage");
                    currentRooms++;
                    break;
                default:
                    Console.WriteLine("error occured");
                    break;

            }
        }
    }
}