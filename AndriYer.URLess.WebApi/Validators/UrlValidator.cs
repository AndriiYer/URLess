using AndriYer.URLess.Application.Implementation;

namespace AndriYer.URLess.WebApi.Validators
{
    public class UrlValidator
    {
        public bool IsUrlValid(string url) => Uri.TryCreate(url, UriKind.Absolute, out _);

        public bool IsShortUrlValid(string shortUrl)
        {
            return shortUrl.Length == ShortUrlGenerator.ShortUrlLength;
        }
    }
}
