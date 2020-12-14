using System;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeMd.Domain.Interfaces
{
    public interface IRecipeService
    {
        public Task<string> TranslateToMarkdownAsync(Uri uri, CancellationToken cancellationToken);

    }

}
