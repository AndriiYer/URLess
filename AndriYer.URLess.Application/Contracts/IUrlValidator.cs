namespace AndriYer.URLess.Application.Contracts
{
    public interface IUrlValidator
    {
        bool IsUrlValid(string url);
        bool IsShortenedUrlValid(string shortenedUrl);
    }
}
