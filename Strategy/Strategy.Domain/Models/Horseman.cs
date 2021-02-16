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
        

        public override int DamageValue(int tx, int ty)
        {
            return 75;
        }

        public override bool CanMove(int x, int y)
        {
            return ! (Math.Abs(X - x) > 10 || Math.Abs(Y - y) > 10);
        }
    }
}