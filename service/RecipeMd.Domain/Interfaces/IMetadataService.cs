using System.Collections.Generic;

namespace RecipeMd.Domain.Interfaces
{
    public interface IMetadataService
    {
        public IEnumerable<string> SupportedSites { get; }
    }
}
