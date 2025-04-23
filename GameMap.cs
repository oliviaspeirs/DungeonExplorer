using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class GameMap
    {

            private Room[,] grid;
            public int Width { get; }
            public int Height { get; }

            public GameMap(int width, int height)
            {
                Width = width;
                Height = height;
                grid = new Room[width, height];

                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                        grid[x, y] = Room.GetRandomRoom();
            }

            public Room GetRoom(int x, int y)
            {
                if (x >= 0 && x < Width && y >= 0 && y < Height)
                    return grid[x, y];
                return null;
            }
        
    }

}

