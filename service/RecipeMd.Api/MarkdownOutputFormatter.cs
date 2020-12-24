using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using RecipeMd.Domain.Dtos;
using RecipeMd.Domain.Interfaces;
using System;
using System.Text;
using System.Threading.Tasks;

namespace RecipeMd.Api
{
    public class MarkdownOutputFormatter : TextOutputFormatter
    {
        private readonly IMarkdownGenerator markdownGenerator;
        private readonly IMarkdownProcessor markdownProcessor;

        public MarkdownOutputFormatter(IMarkdownGenerator markdownGenerator, IMarkdownProcessor markdownProcessor)
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/markdown"));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/html"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
            this.markdownGenerator = markdownGenerator;
            this.markdownProcessor = markdownProcessor;
        }

        protected override bool CanWriteType(Type type)
        {
            return typeof(RecipeDto).IsAssignableFrom(type);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding encoding)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }
            var valueAsRecipe = (RecipeDto)context.Object;

            if (valueAsRecipe == null)
            {
                return Task.CompletedTask;
            }

            var response = context.HttpContext.Response;
            var markdown = markdownGenerator.Generate(valueAsRecipe);
            var body = response.ContentType switch
            {
                string type when type.Contains("text/markdown") => markdown,
                string type when type.Contains("text/html") => markdownProcessor.Transform(markdown),
                _ => markdown
            };
            return response.WriteAsync(body, encoding);
        }
    }
}
