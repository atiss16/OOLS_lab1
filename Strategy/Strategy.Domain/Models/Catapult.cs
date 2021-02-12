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
            PathToImage = "Resources/Units/Catapult.png";
        }
    }
}