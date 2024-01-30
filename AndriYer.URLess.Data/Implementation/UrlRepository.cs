using AndriYer.URLess.Data.Contracts;
using AndriYer.URLess.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace AndriYer.URLess.Data.Implementation
{
    public class UrlRepository(IConfiguration configuration) : IUrlRepository
    {
        private readonly RedisDictionary _urlPairs = new(configuration["ConnectionStrings:Redis"]!);
        
        public Task<Url> GetByShortUrl(string shortUrl, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new Url
            {
                RegularUrl = _urlPairs.TryGetValue(shortUrl, out var value) ? value : default, 
                ShortUrl = shortUrl
            });
        }

        public Task Add(Url url, CancellationToken cancellationToken = default)
        {
            _urlPairs[url.ShortUrl] = url.RegularUrl!;
            
            return Task.CompletedTask;
        }

        public Task<bool> Contains(string shortUrl, CancellationToken cancellationToken = default) =>
            Task.FromResult(_urlPairs.ContainsKey(shortUrl));
    }
}
