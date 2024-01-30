using AndriYer.URLess.Domain.Models;

namespace AndriYer.URLess.Data.Contracts
{
    public interface IUrlRepository
    {
        Task<Url> GetByShortUrl(string shortUrl, CancellationToken cancellationToken = default);
        Task Add(Url url, CancellationToken cancellationToken = default);
        Task<bool> Contains(string shortUrl, CancellationToken cancellationToken = default);
    }
}
