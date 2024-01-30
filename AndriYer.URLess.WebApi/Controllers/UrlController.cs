using AndriYer.URLess.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using AndriYer.URLess.WebApi.Validators;

namespace AndriYer.URLess.WebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("")]
    public class UrlController(ILogger<UrlController> logger, IShortUrlGenerator urlService, UrlValidator urlValidator) : ControllerBase
    {
        [HttpGet]
        [Route("{shortUrl}")]
        public async Task<IActionResult> Get(string shortUrl)
        {
            if (!urlValidator.IsShortUrlValid(shortUrl))
            {
                return BadRequest("Invalid short URL");
            }
                
            logger.LogInformation($"GET URL from shortened '{shortUrl}'");
            var url = await urlService.GetOriginalUrl(shortUrl);

            return string.IsNullOrEmpty(url) 
                ? NotFound() 
                : RedirectPermanent(url);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UrlModel urlModel)
        {
            var originalUrl = urlModel.Url;
            if (!urlValidator.IsUrlValid(originalUrl))
            {
                return BadRequest($"Invalid URL '{originalUrl}'");
            }

            logger.LogInformation($"POST URL '{originalUrl}'");
            var shortUrl = await urlService.CreateShortUrl(originalUrl);
            var host = HttpContext.Request.Host;
            var url = $"http://{host}/{shortUrl}";
            var response = new {Url = url, OriginalURL = originalUrl};

            return Created(originalUrl, response);
        }
    }

    [method: JsonConstructor]
    public record UrlModel(string Url);
}
