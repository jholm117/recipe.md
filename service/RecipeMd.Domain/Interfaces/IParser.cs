
using System;
using System.Threading;
using System.Threading.Tasks;
using RecipeMd.Domain.Dtos;

namespace RecipeMd.Domain.Interfaces
{
    public interface IParser
    {
        public Task<RecipeDto> ParseRecipeHtml(Uri uri, IRecipeSiteProfile profile, CancellationToken cancellationToken);
    }

}
