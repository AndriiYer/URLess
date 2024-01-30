namespace AndriYer.URLess.Application.Contracts
{
    public interface IShortUrlGenerator
    {
        Task<string> CreateShortUrl(string url);
        Task<string?> GetOriginalUrl(string shortUrl);
    }
}
