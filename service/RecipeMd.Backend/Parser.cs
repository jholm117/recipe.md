using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp;
using RecipeMd.Domain.Interfaces;
using RecipeMd.Domain.Dtos;

namespace RecipeMd.Backend
{
    public class Parser : IParser
    {
        public async Task<RecipeDto> ParseRecipeHtml(Uri uri, DomainSelectors profile, CancellationToken cancellationToken)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(uri.OriginalString, cancellation: cancellationToken);
            var title = document.QuerySelector(profile.TitleSelector).TextContent.Trim();
            var ingredients = document.QuerySelectorAll(profile.IngredientSelector).Select(x => x.TextContent.Trim());
            var directions = document.QuerySelectorAll(profile.DirectionSelector).Select(x => x.TextContent.Trim()).ToList();
            var url = uri.ToString();

            return new RecipeDto
            {
                Title = title,
                Ingredients = ingredients,
                Directions = directions,
                Url = url
            };
        }
    }

}
