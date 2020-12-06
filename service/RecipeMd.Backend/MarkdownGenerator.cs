using System;
using HandlebarsDotNet;
using RecipeMd.Domain.Interfaces;
using RecipeMd.Domain.Models;

namespace RecipeMd.Backend
{
    public class MarkdownGenerator : IMarkdownGenerator
    {
        private readonly Func<object, string> template;

        public MarkdownGenerator(string templateSource)
        {
            Handlebars.RegisterHelper("inc", (writer, context, parameters) => writer.WriteSafeString($"{(int)parameters[0] + 1}"));
            template = Handlebars.Compile(templateSource);
        }

        public string Generate(Recipe recipe)
        {
            return template(recipe);
        }
    }
}
