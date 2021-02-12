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
            PathToImage = "Resources/Ground/Grass.png";
        }
    }
}