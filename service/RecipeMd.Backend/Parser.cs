using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp;
using RecipeMd.Domain.Interfaces;
using RecipeMd.Domain.Models;

namespace RecipeMd.Backend
{
    public class Parser : IParser
    {
        public async Task<Recipe> ParseRecipeHtml(string uri, CancellationToken cancellationToken)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(uri, cancellation: cancellationToken);
            var selectors = ChooseSelectors(uri);
            var title = document.QuerySelector(selectors.TitleSelector).TextContent;
            var ingredients = document.QuerySelectorAll(selectors.IngredientSelector).Select(x => x.TextContent);
            var directions = document.QuerySelectorAll(selectors.DirectionSelector).Select(x => x.TextContent).ToList();

            return new Recipe
            {
                Title = title,
                Ingredients = ingredients,
                Directions = directions
            };
        }

        private static RecipeCssSelectors ChooseSelectors(string uri)
        {
            var host = new Uri(uri).Host;
            return host switch
            {
                "cookieandkate.com" => CookieAndKate,
                _ => null,
            };
        }

        private static readonly RecipeCssSelectors CookieAndKate = new RecipeCssSelectors { TitleSelector = "h1.entry-title", DirectionSelector = "div.tasty-recipe-instructions li", IngredientSelector = "div.tasty-recipe-ingredients li" };
    }

}
