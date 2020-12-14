using RecipeMd.Domain.Interfaces;

namespace RecipeMd.Domain.RecipeSiteProfiles
{
    public class CookieAndKateProfile : IRecipeSiteProfile
    {
        public string Domain => "cookieandkate.com";

        public string TitleSelector => "h1.entry-title";

        public string IngredientSelector => "div.tasty-recipe-ingredients li";

        public string DirectionSelector => "div.tasty-recipe-instructions li";
    }
}
