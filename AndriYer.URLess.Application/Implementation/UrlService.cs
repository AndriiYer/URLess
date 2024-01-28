using AndriYer.URLess.Application.Contracts;

namespace AndriYer.URLess.Application.Implementation;

public class UrlService(IShortUrlGenerator shortUrlGenerator) : IUrlService
{
    private readonly IShortUrlGenerator _shortUrlGenerator = shortUrlGenerator;
    
    public Task<string> CreateShortUrl(string url)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetOriginalUrl(string shortenedUrl)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ShortUrlExists(string shortenedUrl)
    {
        throw new NotImplementedException();
    }
}