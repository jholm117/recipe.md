using Microsoft.AspNetCore.Mvc;
using RecipeMd.Domain.Dtos;
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
        private readonly IRecipePresenter recipeService;
        public RecipeController(IRecipePresenter recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet]
        [Route("{*uri}")]
        [Produces("text/markdown", "application/json", "text/html")]
        public Task<RecipeDto> Get(string uri, CancellationToken cancellationToken)
        {
            return recipeService.RecipeAsync(new Uri($"https://{uri}"), cancellationToken);
        }
    }
}
