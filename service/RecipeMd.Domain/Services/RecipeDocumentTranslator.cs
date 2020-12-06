using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RecipeMd.Domain.Interfaces;

namespace RecipeMd.Domain.Services
{
    public class RecipeDocumentTranslator : IRecipeDocumentTranslator
    {
        private readonly IParser parser;
        private readonly IMarkdownGenerator markdownGenerator;
        public RecipeDocumentTranslator(IParser parser, IMarkdownGenerator markdownGenerator)
        {
            this.parser = parser;
            this.markdownGenerator = markdownGenerator;
        }

        public async Task<string> TranslateToMarkdownAsync(string uri, CancellationToken cancellationToken)
        {
            var recipe = await parser.ParseRecipeHtml(uri, cancellationToken);
            return markdownGenerator.Generate(recipe);
        }
    }

}
