using Microsoft.AspNetCore.Mvc;
using RecipeMd.Domain.Interfaces;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeMd.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeDocumentTranslator recipeDocumentTranslator;
        public RecipeController(IRecipeDocumentTranslator recipeDocumentTranslator)
        {
            this.recipeDocumentTranslator = recipeDocumentTranslator;
        }

        [HttpGet]
        [Route("{uri}")]
        [Produces("text/markdown")]
        public Task<string> Get(string uri, CancellationToken cancellationToken)
        {
            return recipeDocumentTranslator.TranslateToMarkdownAsync(WebUtility.UrlDecode(uri), cancellationToken);
        }
    }

}
