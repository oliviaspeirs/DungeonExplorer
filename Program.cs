using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        // <summary>
        // main method, initalises the game and runs it
        // </summary>
        static void Main(string[] args)
        {
            Game game = new Game(); // Create new game object
            game.Start(); //Start game by calling the start function
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
