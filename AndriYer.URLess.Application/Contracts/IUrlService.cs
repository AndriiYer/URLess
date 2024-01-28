namespace AndriYer.URLess.Application.Contracts
{
    public interface IUrlService
    {
        Task<string> CreateShortUrl(string url);
        Task<string> GetOriginalUrl(string shortenedUrl);
        Task<bool> ShortUrlExists(string shortenedUrl);
    }
}
