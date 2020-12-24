using RecipeMd.Domain.Interfaces;
using System.Collections.Generic;

namespace RecipeMd.Backend
{
    public class DomainSelectorProvider : IDomainSelectorProvider
    {
        private static readonly IEnumerable<DomainSelectors> profiles = new DomainSelectors[]
        {
            new DomainSelectors(
                "cookieandkate.com",
                "h1.entry-title",
                "div.tasty-recipe-ingredients li",
                "div.tasty-recipe-instructions li"),
            new DomainSelectors(
                "allrecipes.com",
                ".recipe-main-header .headline",
                ".ingredients-item-name",
                ".instructions-section-item p")
    };


        IEnumerable<DomainSelectors> IDomainSelectorProvider.Profiles => profiles;
    }
}
