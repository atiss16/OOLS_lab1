namespace Strategy.Domain.Models
{
    /// <summary>
    /// Катапульта.
    /// </summary>
    public sealed class Catapult : Unit
    {
        /// <inheritdoc />
        public Catapult(Player player) : base(player)
        {
            
        }

        protected override string PathToImage { get => "Resources/Units/Catapult.png"; }

        private int hp = 75;
        protected override int Hp { get => hp; set => hp = value; }        

        public override int DamageValue(int tx, int ty)
        {
            int d = 100;

            var dx = X - tx;
            var dy = Y - ty;

            if ((dx == -1 || dx == 0 || dx == 1) &&
                (dy == -1 || dy == 0 || dy == 1))
            {
                d /= 2;
            }

            return d;
        }
    }
}