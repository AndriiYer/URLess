using AndriYer.URLess.Data.Contracts;
using AndriYer.URLess.Domain.Models;

namespace AndriYer.URLess.Data.Implementation
{
    public class UrlRepository : IUrlRepository
    {
        public Task<Url> GetByShortUrlAsync(string shortUrl, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task AddOrUpdateAsync(Url url, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
