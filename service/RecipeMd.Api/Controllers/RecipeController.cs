using Microsoft.AspNetCore.Mvc;
using RecipeMd.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeMd.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService recipeService;
        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet]
        [Route("{*uri}")]
        [Produces("text/markdown")]
        public Task<string> Get(string uri, CancellationToken cancellationToken)
        {
            return recipeService.TranslateToMarkdownAsync(new Uri($"https://{uri}"), cancellationToken);
        }
    }

}
