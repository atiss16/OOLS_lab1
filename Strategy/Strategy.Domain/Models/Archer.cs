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
            PathToImage = "Resources/Units/Archer.png";
        }
    }
}