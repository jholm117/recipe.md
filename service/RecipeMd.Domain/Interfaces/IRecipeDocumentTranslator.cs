using System.Threading;
using System.Threading.Tasks;

namespace RecipeMd.Domain.Interfaces
{

    public interface IRecipeDocumentTranslator
    {
        public Task<string> TranslateToMarkdownAsync(string uri, CancellationToken cancellationToken);

    }

}
