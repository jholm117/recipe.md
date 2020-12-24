using System.Collections.Generic;

namespace RecipeMd.Domain.Interfaces
{
    public interface IMetadataPresenter
    {
        public IEnumerable<string> SupportedSites { get; }
    }
}
