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
            var cr = GetObjectCoordinates(tu);
            Player ptu;
            if (tu is Archer a)
            {
                ptu = a.Player;
            }
            else if (tu is Catapult c)
            {
                ptu = c.Player;
            }
            else if (tu is Horseman h)
            {
                ptu = h.Player;
            }
            else if (tu is Swordsman s)
            {
                ptu = s.Player;
            }
            else
                throw new ArgumentException("Неизвестный тип");

            if (tu is Unit tu1&& tu1.IsDead())
                return false;

            if (au is Archer a1)
            {
                if (a1.Player == ptu)
                    return false;

                var dx = a1.X - cr.X;
                var dy = a1.Y - cr.Y;

                return dx >= -5 && dx <= 5 && dy >= -5 && dy <= 5;
            }

            if (au is Catapult c1)
            {
                if (c1.Player == ptu)
                    return false;

                var dx = c1.X - cr.X;
                var dy = c1.Y - cr.Y;

                return dx >= -10 && dx <= 10 && dy >= -10 && dy <= 10;
            }

            if (au is Horseman h1)
            {
                if (h1.Player == ptu)
                    return false;

                var dx = h1.X - cr.X;
                var dy = h1.Y - cr.Y;

                return (dx == -1 || dx == 0 || dx == 1) &&
                       (dy == -1 || dy == 0 || dy == 1);
            }

            if (au is Swordsman s1)
            {
                if (s1.Player == ptu)
                    return false;

                var dx = s1.X - cr.X;
                var dy = s1.Y - cr.Y;

                return (dx == -1 || dx == 0 || dx == 1) &&
                       (dy == -1 || dy == 0 || dy == 1);
            }

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

        /// <summary>
        /// Получить изображение по указанному пути.
        /// </summary>
        private static ImageSource BuildSourceFromPath(string path)
        {
            return new BitmapImage(new Uri(path, UriKind.Relative));
        }
    }
}