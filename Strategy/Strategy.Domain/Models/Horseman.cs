using System;

namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс всадника.
    /// </summary>
    public sealed class Horseman : Unit
    {
        /// <inheritdoc />
        public Horseman(Player player) : base (player)
        {

        }

        protected override string PathToImage { get => "Resources/Ground/Horseman.png"; }

        private int hp = 200;
        protected override int Hp { get => hp; set => hp = value; }
        protected override int MaximumAttackDistance => 1;

        protected override int MaximumMoveDistance => 10;

        public override int DamageValue(int tx, int ty)
        {
            return 75;
        }

    }
}