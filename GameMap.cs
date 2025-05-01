using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents the game's map as a 2D grid of <see cref="Room"/> objects.
    /// This means the user is told when they have already been in a room.
    /// </summary>
    public class GameMap
    {

        private Room[,] grid;
        public int Width { get; } /// Gets the width (number of columns) of the map.
        public int Height { get; } /// Gets the height (number of rows) of the map.

        /// <summary>
        /// Initializes a new instance of the <see cref="GameMap"/> class with the specified dimensions.
        /// Each room in the map is initialized as a randomly generated room.
        /// </summary>
        /// <param name="width">The width (columns) of the map.</param>
        /// <param name="height">The height (rows) of the map.</param>
        public GameMap(int width, int height)
        {
            Width = width;
            Height = height;
            grid = new Room[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    grid[x, y] = Room.GetRandomRoom();
        }

        /// <summary>
        /// Retrieves the <see cref="Room"/> at the specified coordinates.
        /// </summary>
        /// <param name="x">The X-coordinate (column index).</param>
        /// <param name="y">The Y-coordinate (row index).</param>
        /// <returns>The <see cref="Room"/> at the given coordinates, or null if out of bounds.</returns>
        public Room GetRoom(int x, int y)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
                return grid[x, y];
            return null;
        }
        
    }

}

