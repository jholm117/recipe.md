using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RecipeMd.Domain.Dtos;
using RecipeMd.Domain.Interfaces;

namespace RecipeMd.Domain.Services
{
    public class RecipePresenter : IRecipePresenter
    {
        private readonly IParser parser;
        private readonly IDomainSelectorProvider profileProvider;
        public RecipePresenter(IParser parser, IDomainSelectorProvider domainSelecltorProvider)
        {
            this.parser = parser;
            this.profileProvider = domainSelecltorProvider;
        }

        public async Task<RecipeDto> RecipeAsync(Uri uri, CancellationToken cancellationToken)
        {
            var profile = profileProvider.Profiles.First(x => x.Domain.Equals(uri.Host));
            return await parser.ParseRecipeHtml(uri, profile, cancellationToken).ConfigureAwait(false);
        }
    }
}
