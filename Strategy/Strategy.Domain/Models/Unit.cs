using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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

        /// <summary>
        /// Изображение мертвого юнита.
        /// </summary>
        public ImageSource DeadImage
        {
            get
            {
                return BuildSourceFromPath(PathToImage);
            }
        }
    }
}
