using RecipeMd.Domain.Dtos;

namespace RecipeMd.Domain.Interfaces
{
    public interface IMarkdownGenerator
    {
        public string Generate(RecipeDto recipe);
    }

}
