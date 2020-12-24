namespace RecipeMd.Domain.Interfaces
{
    public interface IMarkdownProcessor
    {
        public string Transform(string markdownText);
    }
}
