using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents an entity that can take damage and has health.
    /// </summary>
    public interface IDamageable
    {
        int Health { get; set; } /// Gets or sets the health of the entity.
        void TakeDamage(int damage); /// Applies damage to the entity.
    }

    /// <summary>
    /// Represents an item or object that can be used by a player.
    /// </summary>
    public interface IUsable
    {
        void Use(Player player); /// Defines how the object is used by the player.
    }


}
