using MarkdownSharp;
using RecipeMd.Domain.Interfaces;

namespace RecipeMd.Backend
{
    public class MarkdownProcessor : IMarkdownProcessor
    {
        private readonly Markdown markdownSharp;

        public MarkdownProcessor()
        {
            markdownSharp = new Markdown();
        }

        public string Transform(string text) => markdownSharp.Transform(text);

    }
}
