
using System;
using System.Threading;
using System.Threading.Tasks;
using RecipeMd.Domain.Models;

namespace RecipeMd.Domain.Interfaces
{
    public interface IParser
    {
        public Task<Recipe> ParseRecipeHtml(Uri uri, CancellationToken cancellationToken);
    }

}
