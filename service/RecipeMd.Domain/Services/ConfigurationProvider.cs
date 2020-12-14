using System.Collections.Generic;
using System.IO;
using System.Reflection;
using RecipeMd.Domain.Interfaces;
using RecipeMd.Domain.RecipeSiteProfiles;

namespace RecipeMd.Domain.Services
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        private static readonly IEnumerable<IRecipeSiteProfile> profiles = new List<IRecipeSiteProfile>{
            new CookieAndKateProfile()
        };
        private static readonly string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "handlebars-templates", "recipe-template.handlebars");
        private static readonly string handlebarsTemplateSource = File.ReadAllText(path);

        public IEnumerable<IRecipeSiteProfile> Profiles => profiles;

        public string HandlebarsTemplateSource => handlebarsTemplateSource;
    }
}
