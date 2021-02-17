using System;
using System.Windows.Media;

namespace Strategy.Domain.Models
{
    /// <summary>
    /// Лучник.
    /// </summary>
    public sealed class Archer : Unit
    {

        /// <inheritdoc />
        public Archer(Player player) : base(player)
        {

        }

        protected override string PathToImage { get => "Resources/Units/Archer.png"; }

        private int hp = 50;
        protected override int Hp { get => hp; set => hp = value; }

        protected override int MaximumAttackDistance => 5;

        public override int DamageValue(int tx, int ty)
        {
            int d = 50;

            var dx = Math.Abs(X - tx);
            var dy = Math.Abs(Y - ty);

            if ((dx <= 1) && (dy <= 1))
                d /= 2;

            return d;
        }

        public override bool CanMove(int x, int y)
        {
            return !(Math.Abs(X - x) > 3 || Math.Abs(Y - y) > 3);
        }
    }
}