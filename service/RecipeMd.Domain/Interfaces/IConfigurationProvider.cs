using System.Collections.Generic;

namespace RecipeMd.Domain.Interfaces
{
    public interface IConfigurationProvider
    {
        public IEnumerable<IRecipeSiteProfile> Profiles { get; }
        public string HandlebarsTemplateSource { get; }
    }
}
