using System.Collections.Generic;
using System.Linq;
using RecipeMd.Domain.Interfaces;

namespace RecipeMd.Domain.Services
{
    public class MetadataService : IMetadataService
    {
        private readonly IConfigurationProvider profileProvider;

        public MetadataService(IConfigurationProvider profiles)
        {
            this.profileProvider = profiles;
        }

        public IEnumerable<string> SupportedSites => profileProvider.Profiles.Select(x => x.Domain);
    }
}
