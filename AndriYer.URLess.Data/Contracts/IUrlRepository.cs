using AndriYer.URLess.Domain.Models;

namespace AndriYer.URLess.Data.Contracts
{
    public interface IUrlRepository
    {
        Task<Url> GetByShortUrlAsync(string shortUrl, CancellationToken cancellationToken = default);
        Task AddOrUpdateAsync(Url url, CancellationToken cancellationToken = default);
    }
}
