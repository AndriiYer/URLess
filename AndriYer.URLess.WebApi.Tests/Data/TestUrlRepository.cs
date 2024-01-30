using AndriYer.URLess.Data.Contracts;
using AndriYer.URLess.Domain.Models;
using System.Collections.Concurrent;

namespace AndriYer.URLess.WebApi.Tests.Data
{
    public class TestUrlRepository(TestDataBase database) : IUrlRepository
    {
        public Task<Url> GetByShortUrl(string shortUrl, CancellationToken cancellationToken = default) =>
            database.GetValueOrDefault(shortUrl, cancellationToken);

        public Task Add(Url url, CancellationToken cancellationToken = default) => 
            database.Add(url, cancellationToken);

        public Task<bool> Contains(string shortUrl, CancellationToken cancellationToken = default) =>
            database.Contains(shortUrl, cancellationToken);
    }
}
