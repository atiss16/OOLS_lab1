namespace Strategy.Domain.Models
{
    /// <summary>
    /// Проходимая поверхность на земле.
    /// </summary>
    public sealed class Grass : Cell
    {
        /// <inheritdoc />
        public Grass() : base()
        {

        }
        protected override string PathToImage { get => "Resources/Ground/Grass.png"; }
    }
}