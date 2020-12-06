using RecipeMd.Domain.Models;

namespace RecipeMd.Domain.Interfaces
{
    public interface IMarkdownGenerator
    {
        public string Generate(Recipe recipe);
    }

}
