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
        /// Максимальное расстояние, на котором возможна атака.
        /// </summary>
        protected abstract int MaximumAttackDistance { get; }

        /// <summary>
        /// Изображение мертвого юнита.
        /// </summary>
        public ImageSource DeadImage { get => BuildSourceFromPath("Resources/Units/Dead.png"); }

        /// <summary>
        /// Метод уменьшения здоровья.
        /// </summary>
        /// <param name="damageValue">Величина урона.</param>
        public void MinusHp (int damageValue)
        {
            Hp = Math.Max(Hp - damageValue, 0);
        }

        /// <summary>
        /// Вычисление урона.
        /// </summary>
        /// <param name="tx">Координата x юнита, который является целью</param>
        /// <param name="ty">Координата y юнита, который является целью</param>
        /// <returns>
        /// Возвращает <see langvalue="int" /> величину урона
        /// </returns>
        public abstract int DamageValue(int tx, int ty);

        /// <summary>
        /// Проверка на возможность атаки.
        /// </summary>
        /// <param name="targetUnit">Юнит, который является целью</param>
        /// <returns>
        /// <see langvalue="true" />, если атака возможна
        /// <see langvalue="false" /> - иначе.
        /// </returns>
        public bool CanAttack(Unit targetUnit)
        {
            if (targetUnit.IsDead())
                return false;

            if (Player == targetUnit.Player)
                return false;

            var dx = Math.Abs(X - targetUnit.X);
            var dy = Math.Abs(Y - targetUnit.Y);

            return dx <= MaximumAttackDistance && dy <= MaximumAttackDistance;
        }


        /// <summary>
        /// Проверка на возможность перемещения.
        /// </summary>
        public abstract bool CanMove(int x, int y);

        /// <summary>
        /// Проверка на смерть.
        /// </summary>
        public bool IsDead()
        {
            return Hp == 0;
        }
    }
}
