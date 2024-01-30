namespace AndriYer.URLess.Domain.Models
{
    public class Url
    {
        public string ShortUrl { get; set; } = default!;
        
        public string? RegularUrl { get; set; }
    }
}
