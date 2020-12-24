using RecipeMd.Domain.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeMd.Domain.Interfaces
{
    public interface IRecipePresenter
    {
        public Task<RecipeDto> RecipeAsync(Uri uri, CancellationToken cancellationToken);

    }

}
