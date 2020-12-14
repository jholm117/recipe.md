using System;
using HandlebarsDotNet;
using RecipeMd.Domain.Interfaces;
using RecipeMd.Domain.Dtos;

namespace RecipeMd.Backend
{
    public class MarkdownGenerator : IMarkdownGenerator
    {
        private readonly Func<object, string> template;

        public MarkdownGenerator(IConfigurationProvider configurationProvider)
        {
            Handlebars.RegisterHelper("inc", (writer, context, parameters) => writer.WriteSafeString($"{(int)parameters[0] + 1}"));
            template = Handlebars.Compile(configurationProvider.HandlebarsTemplateSource);
        }

        public string Generate(RecipeDto recipe)
        {
            return template(recipe);
        }
    }
}
