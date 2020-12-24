using Microsoft.AspNetCore.Mvc.Testing;
using Snapshooter;
using Snapshooter.Xunit;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace RecipeMd.Api.Test
{
    public class RecipeTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public RecipeTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            //_client = new RecipeClient(httpClient);
        }

        [Theory]
        [InlineData("application/json")]
        [InlineData("text/markdown")]
        [InlineData("text/html")]
        public async Task GetRecipe_ValidAcceptHeader_ReturnsRequestedContentType(string contentType)
        {
            _client.DefaultRequestHeaders.Add("Accept", contentType);
            var response = await _client.GetAsync("/recipe/cookieandkate.com/flax-egg-recipe/").ConfigureAwait(false);

            Assert.Contains(contentType, response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("text/cmd")]

        public async Task GetRecipe_UnsupportedAcceptHeader_NotAcceptable(string contentType)
        {
            _client.DefaultRequestHeaders.Add("Accept", contentType);
            var response = await _client.GetAsync("/recipe/cookieandkate.com/flax-egg-recipe/").ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.NotAcceptable, response.StatusCode);
        }

        [Theory]
        [InlineData("cookieandkate.com/classic-mulled-wine-recipe/")]
        [InlineData("cookieandkate.com/gluten-free-banana-bread-recipe/")]
        [InlineData("cookieandkate.com/flax-egg-recipe/")]
        [InlineData("cookieandkate.com/healthy-banana-bread-recipe/")]
        [InlineData("allrecipes.com/recipe/282602/chef-johns-individual-beef-wellingtons/")]
        public async Task SupportedSites_ShouldMatchSnapshot(string recipeUri)
        {
            // Act
            var response = await _client.GetAsync($"/recipe/{recipeUri}").ConfigureAwait(false);

            Path.GetInvalidFileNameChars().ToList().ForEach(x => recipeUri = recipeUri.Replace(x, '#'));

            var recipe = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            // Assert
            Snapshot.Match(recipe, SnapshotNameExtension.Create(recipeUri));

        }
    }
}
