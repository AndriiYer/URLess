namespace AndriYer.URLess.WebApi.Tests.Controllers
{
    public class UrlControllerTests : IDisposable
    {
        private WebApiTestFactory _webApiFactory;
        private HttpClient _client;

        public UrlControllerTests(WebApiTestFactory webApiFactory)
        {
            _webApiFactory = webApiFactory;
            _client = _webApiFactory.CreateClient();
        }
        
        [Fact]
        public async Task UrlController_GetExistingShortUrl_Returns301Result()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public async Task UrlController_GetNonExistingShortUrl_Returns404Result()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public async Task UrlController_PostNonExistingUrl_ReturnsShortUrl()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public async Task UrlController_PostExistingUrl_ReturnsNewShortUrl()
        {
            // Arrange
            // Act
            // Assert
        }

        public void Dispose()
        {
            _webApiFactory.Dispose();
            _client.Dispose();
        }
    }
}
