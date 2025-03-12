using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Test
    {
        // create player object
        Player player;

        public Test(Player _player) 
        {
            player = _player;
        }

        public void PlayerTesting()
        {
            Debug.Assert(player.Name != null, "Player has no name.");
            Debug.Assert(player.Inventory != null, "Player inventory not created.");
            Debug.Assert(player.Health != 0, "Player has incorrect initial health.");
        }
    }
}
