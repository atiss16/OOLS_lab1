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
        /// Максимальное расстояние, на которое можно передвинуться.
        /// </summary>
        protected abstract int MaximumMoveDistance { get; }

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
        public abstract int DamageValue(int tx, int ty);

        /// <summary>
        /// Проверка на возможность атаки.
        /// </summary>
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
        /// Может ли юнит передвинуться в указанную клетку.
        /// </summary>
        public bool CanMove(int x, int y)
        {
            return !(Math.Abs(X - x) > MaximumMoveDistance || Math.Abs(Y - y) > MaximumMoveDistance);
        }

        /// <summary>
        /// Проверка на смерть.
        /// </summary>
        public bool IsDead()
        {
            return Hp == 0;
        }
    }
}
