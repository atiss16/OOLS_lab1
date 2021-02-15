namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс мечника.
    /// </summary>
    public sealed class Swordsman : Unit
    {
        public Swordsman(Player player) : base (player)
        {

        }

        protected override string PathToImage { get => "Resources/Ground/Swordsman.png"; }
    }
}