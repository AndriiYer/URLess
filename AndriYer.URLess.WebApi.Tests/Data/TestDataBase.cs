using AndriYer.URLess.Domain.Models;

namespace AndriYer.URLess.WebApi.Tests.Data;

public class TestDataBase
{
    private readonly Dictionary<string, string> _urlPairs = new();

    public Task<Url> GetValueOrDefault(string shortUrl, CancellationToken cancellationToken = default) =>
        Task.FromResult(new Url
        {
            RegularUrl = _urlPairs.GetValueOrDefault(shortUrl), 
            ShortUrl = shortUrl
        });

    public Task Add(Url url, CancellationToken cancellationToken = default)
    {
        _urlPairs[url.ShortUrl] = url.RegularUrl!;
            
        return Task.CompletedTask;
    }

    public Task<bool> Contains(string shortUrl, CancellationToken cancellationToken = default) =>
        Task.FromResult(_urlPairs.ContainsKey(shortUrl));
}