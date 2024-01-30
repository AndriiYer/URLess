using System.Net;
using System.Net.Mime;
using System.Text;
using AndriYer.URLess.WebApi.Controllers;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace AndriYer.URLess.WebApi.Tests.Controllers
{
    public class UrlControllerTests : IClassFixture<WebApiTestFactory>//, IDisposable
    {
        private readonly WebApiTestFactory _webApiFactory;
        private readonly HttpClient _client;

        public UrlControllerTests(WebApiTestFactory webApiFactory)
        {
            _webApiFactory = webApiFactory;
            _client = _webApiFactory.CreateClient();
            _client.BaseAddress = new("http://localhost");
        }
        
        [Fact]
        public async Task UrlController_GetExistingShortUrl_Returns301Result()
        {
            // Arrange
            const string egularUrl = "https://google.com";
            const HttpStatusCode expectedStatusCode = HttpStatusCode.MovedPermanently;
            var shortUrl =  await Post(egularUrl); //http://localhost/Mnw_2o

            // Act
            var response = await _client.GetAsync(shortUrl);
            
            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(expectedStatusCode);
            var location = response.Headers.Location;
            location.Should().Be(egularUrl);
        }

        [Fact]
        public async Task UrlController_GetNonExistingShortUrl_Returns404Result()
        {
            // Arrange
            const string url = "https://nonexisting.com";
            const HttpStatusCode expectedStatusCode = HttpStatusCode.NotFound;

            // Act
            var response = await _client.GetAsync(url);

            // Assert
            response.StatusCode.Should().Be(expectedStatusCode);
        }

        [Fact]
        public async Task UrlController_GetInvalidUrl_ReturnsBadRequest()
        {
            // Arrange
            const string url = "inv@lid URL";
            const HttpStatusCode expectedStatusCode = HttpStatusCode.BadRequest;

            // Act
            var response = await _client.GetAsync(url);

            // Assert
            response.StatusCode.Should().Be(expectedStatusCode);
        }

        [Fact]
        public async Task UrlController_PostNonExistingUrl_Returns201Result()
        {
            // Arrange
            const string url = "https://extraurl.com";
            const HttpStatusCode expectedStatusCode = HttpStatusCode.Created;

            // Act
            var response = await PostRaw(url);

            // Assert
            response.StatusCode.Should().Be(expectedStatusCode);
        }

        [Fact]
        public async Task UrlController_PostExistingUrl_ReturnsNewShortUrl()
        {
            // Arrange
            const string url = "https://extraurl.com";
            
            // Act
            var response1 = await Post(url);
            var response2 = await Post(url);
            var response3 = await Post(url);

            // Assert
            response1.Should().NotBe(response2);
            response2.Should().NotBe(response3);
        }

        [Fact]
        public async Task UrlController_PostInvalidUrl_ReturnsBadRequest()
        {
            // Arrange
            var url = "invalidurl";
            var expectedStatusCode = HttpStatusCode.BadRequest;

            // Act
            var response = await PostRaw(url);

            // Assert
            response.StatusCode.Should().Be(expectedStatusCode);
        }

        public void Dispose()
        {
            _webApiFactory.Dispose();
            _client.Dispose();
        }

        private async Task<string> Post(string url)
        {
            var response = await PostRaw(url);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseModel = JsonConvert.DeserializeObject<UrlModel>(responseContent)!;

            return responseModel.Url;
        }

        private async Task<HttpResponseMessage> PostRaw(string url)
        {
            UrlModel model = new(url);
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await _client.PostAsync(string.Empty, content);
            
            return response;
        }
    }
}
