namespace AndriYer.URLess.Application.Contracts
{
    public interface IShortUrlGenerator
    {
        string GenerateShortUrl(string longUrl);
    }
}
