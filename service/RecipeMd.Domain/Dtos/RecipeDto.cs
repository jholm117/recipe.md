using System.Collections.Generic;

namespace RecipeMd.Domain.Dtos
{
    public class RecipeDto
    {
        public string Title { get; set; }
        public IList<string> Directions { get; set; }
        public IEnumerable<string> Ingredients { get; set; }
        public string Url { get; set; }
    }

}
