using System.Collections.Generic;

namespace RecipeMd.Domain.Interfaces
{
    public interface IDomainSelectorProvider
    {
        public IEnumerable<DomainSelectors> Profiles { get; }
    }
}
