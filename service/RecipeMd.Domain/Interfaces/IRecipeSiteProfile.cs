namespace RecipeMd.Domain.Interfaces
{
    public interface IRecipeSiteProfile
    {
        public string Domain { get; }
        public string TitleSelector { get; }
        public string IngredientSelector { get; }
        public string DirectionSelector { get; }
    }
}
