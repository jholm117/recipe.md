using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RecipeMd.Domain.Interfaces;

namespace RecipeMd.Domain.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IParser parser;
        private readonly IMarkdownGenerator markdownGenerator;
        private readonly IConfigurationProvider profileProvider;
        public RecipeService(IParser parser, IMarkdownGenerator markdownGenerator, IConfigurationProvider profiles)
        {
            this.parser = parser;
            this.markdownGenerator = markdownGenerator;
            this.profileProvider = profiles;
        }

        public async Task<string> TranslateToMarkdownAsync(Uri uri, CancellationToken cancellationToken)
        {
            var profile = profileProvider.Profiles.Where(x => x.Domain.Equals(uri.Host)).First();
            var recipe = await parser.ParseRecipeHtml(uri, profile, cancellationToken);
            return markdownGenerator.Generate(recipe);
        }
    }
}
