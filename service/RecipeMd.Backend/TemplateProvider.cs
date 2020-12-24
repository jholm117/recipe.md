using System.IO;
using System.Reflection;
using RecipeMd.Domain.Interfaces;

namespace RecipeMd.Backend
{
    public class TemplateProvider : ITemplateProvider
    {
        public TemplateProvider(string filePath)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);
            HandlebarsTemplateSource = File.ReadAllText(path);
        }

        public string HandlebarsTemplateSource { get; }
    }
}
