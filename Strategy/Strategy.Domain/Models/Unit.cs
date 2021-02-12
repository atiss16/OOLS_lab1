using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Domain.Models
{
    public abstract class Unit : Cell
    {
        public Unit(Player player)
        {
            Player = player;
        }
        /// <summary>
        /// Игрок, который управляет юнитом.
        /// </summary>
        public Player Player { get; }
    }
}
