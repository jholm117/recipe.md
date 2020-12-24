using System.Collections.Generic;
using System.Linq;
using RecipeMd.Domain.Interfaces;

namespace RecipeMd.Domain.Services
{
    public class MetadataPresenter : IMetadataPresenter
    {
        private readonly IDomainSelectorProvider profileProvider;

        public MetadataPresenter(IDomainSelectorProvider profiles)
        {
            this.profileProvider = profiles;
        }

        public IEnumerable<string> SupportedSites => profileProvider.Profiles.Select(x => x.Domain);
    }
}
