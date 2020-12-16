using Microsoft.AspNetCore.Mvc.Testing;
using RecipeMd.Api.Client;
using RecipeMd.Api.Client.Contracts;
using Snapshooter;
using Snapshooter.Xunit;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RecipeMd.Api.Test
{
    public class RecipeTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly IRecipeClient _client;

        public RecipeTests(WebApplicationFactory<Startup> factory)
        {
            _client = new RecipeClient(factory.CreateClient());
        }

        [Theory]
        [InlineData("cookieandkate.com/classic-mulled-wine-recipe/")]
        [InlineData("cookieandkate.com/gluten-free-banana-bread-recipe/")]
        [InlineData("cookieandkate.com/flax-egg-recipe/")]
        [InlineData("cookieandkate.com/healthy-banana-bread-recipe/")]
        public async Task SupportedSites_ShouldMatchSnapshot(string recipeUri)
        {
            // Act
            var response = await _client.GetAsync(recipeUri);

            Path.GetInvalidFileNameChars().ToList().ForEach(x => recipeUri = recipeUri.Replace(x, '#'));

            // Assert
            Snapshot.Match(response, SnapshotNameExtension.Create(recipeUri));

        }
    }
}
