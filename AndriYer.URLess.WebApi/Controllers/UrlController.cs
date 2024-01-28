using Microsoft.AspNetCore.Mvc;

namespace AndriYer.URLess.WebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("")]
    public class UrlController(ILogger<UrlController> logger) : ControllerBase
    {
        private readonly ILogger<UrlController> _logger = logger;

        [HttpGet]
        [Route("{shortenedUrl}")]
        public async Task<IActionResult> Get([FromQuery] string shortenedUrl)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UrlModel urlModel)
        {
            throw new NotImplementedException();
        }
    }

    public record UrlModel(string Url);
}
