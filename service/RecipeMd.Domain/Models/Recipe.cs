using System.Collections.Generic;

namespace RecipeMd.Domain.Models
{
    public class Recipe
    {
        public string Title { get; set; }
        public IList<string> Directions { get; set; }
        public IEnumerable<string> Ingredients { get; set; }
    }

}
