using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Strategy.Domain.Models;

namespace Strategy.Domain
{
    /// <summary>
    /// Контроллер хода игры.
    /// </summary>
    public class GameController
    {
        private readonly Map _map;

        /// <inheritdoc />
        public GameController(Map map)
        {
            _map = map;
        }

        /// <summary>
        /// Получить координаты объекта.
        /// </summary>
        /// <param name="o">Координаты объекта, которые необходимо получить.</param>
        /// <returns>Координата x, координата y.</returns>
        public Coordinates GetObjectCoordinates(object o)
        {
            if (o is Cell c)
                return new Coordinates(c.X, c.Y);
            throw new ArgumentException("Неизвестный тип");
        }

        /// <summary>
        /// Может ли юнит передвинуться в указанную клетку.
        /// </summary>
        /// <param name="u">Юнит.</param>
        /// <param name="x">Координата X клетки.</param>
        /// <param name="y">Координата Y клетки.</param>
        /// <returns>
        /// <see langvalue="true" />, если юнит может переместиться
        /// <see langvalue="false" /> - иначе.
        /// </returns>
        public bool CanMoveUnit(object u, int x, int y)
        {
            if (u is Unit unit) {
                if (!unit.CanMove(x, y))
                    return false;
            }
            else
                throw new ArgumentException("Неизвестный тип");
            
            foreach (object g in _map.Ground)
            {
                if (g is Water w && w.X == x && w.Y == y)
                {
                    return false;
                }
            }

            foreach (object u1 in _map.Units)
            {
                if (u1 is Unit tmpUnit)
                {
                    if (tmpUnit.X == x && tmpUnit.Y == y)
                        return false;
                }
                else
                    throw new ArgumentException("Неизвестный тип");
            }
            return true;
        }

        /// <summary>
        /// Передвинуть юнита в указанную клетку.
        /// </summary>
        /// <param name="u">Юнит.</param>
        /// <param name="x">Координата X клетки.</param>
        /// <param name="y">Координата Y клетки.</param>
        public void MoveUnit(object u, int x, int y)
        {
            if (!CanMoveUnit(u, x, y))
                return;

            if (u is Unit unit)
            {
                unit.X = x;
                unit.Y = y;
            }
            else
                throw new ArgumentException("Неизвестный тип");
        }

        /// <summary>
        /// Проверить, может ли один юнит атаковать другого.
        /// </summary>
        /// <param name="au">Юнит, который собирается совершить атаку.</param>
        /// <param name="tu">Юнит, который является целью.</param>
        /// <returns>
        /// <see langvalue="true" />, если атака возможна
        /// <see langvalue="false" /> - иначе.
        /// </returns>
        public bool CanAttackUnit(object au, object tu)
        {
            if (tu is Unit targetUnit && au is Unit attackingUnit)
            {
                return attackingUnit.CanAttack(targetUnit);
            }
            else
                throw new ArgumentException("Неизвестный тип");
        }

        /// <summary>
        /// Атаковать указанного юнита.
        /// </summary>
        /// <param name="au">Юнит, который собирается совершить атаку.</param>
        /// <param name="tu">Юнит, который является целью.</param>
        public void AttackUnit(object au, object tu)
        {
            if (!CanAttackUnit(au, tu))
                return;

            if (au is Unit attackingUnit && tu is Unit targetUnit)
            {
                int damage = attackingUnit.DamageValue(targetUnit.X, targetUnit.Y);
                targetUnit.MinusHp(damage);
            }
            else
                throw new ArgumentException("Неизвестный тип");            
        }

        /// <summary>
        /// Получить изображение объекта.
        /// </summary>
        public ImageSource GetObjectSource(object o)
        {
            if (o is Unit u)
            {
                if (u.IsDead())
                    return u.DeadImage;

                return u.Image;
            }

            if (o is Cell c)
                return c.Image;

            throw new ArgumentException("Неизвестный тип");
        }
    }
}