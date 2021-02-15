namespace Strategy.Domain.Models
{
    /// <summary>
    /// Непроходимая наземная поверхность.
    /// </summary>
    public sealed class Water : Cell
    {

        /// <inheritdoc />
        public Water() : base()
        {

        }

        protected override string PathToImage { get => "Resources/Ground/Water.png"; }
    }
}