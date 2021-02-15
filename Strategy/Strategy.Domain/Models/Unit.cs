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
        /// Здоровье.
        /// </summary>
        protected abstract int Hp { get; set; }

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

        /// <summary>
        /// Метод уменьшения здоровья.
        /// </summary>
        protected void MinusHp (int damageValue)
        {
            Hp = Math.Max(Hp - damageValue, 0);
        }

        /// <summary>
        /// Вычисление урона.
        /// </summary>
        public abstract int DamageValue(int tx, int ty);

        /// <summary>
        /// Проверка на смерть.
        /// </summary>
        public bool IsDead()
        {
            return Hp == 0;
        }
    }
}
