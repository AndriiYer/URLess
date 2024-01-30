using System.Security.Cryptography;
using AndriYer.URLess.Application.Contracts;
using AndriYer.URLess.Data.Contracts;
using AndriYer.URLess.Domain.Models;
using System.Text;
using System;

namespace AndriYer.URLess.Application.Implementation;

public class ShortUrlGenerator(IUrlRepository urlRepository) : IShortUrlGenerator
{
    private readonly Random _random = new();

    public const int ShortUrlLength = 6;
    
    public async Task<string> CreateShortUrl(string regularUrl)
    {
        string shortUrl;
        var originalUrl = regularUrl;
        do
        {
            using var sha1 = SHA1.Create();
            var hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(regularUrl));
            
            shortUrl = ToUrlSafeBase64(hashBytes).Substring(0, ShortUrlLength);
            if (await urlRepository.Contains(shortUrl))
            {
                regularUrl = MutateUrl(regularUrl);
            }
        }
        while (await urlRepository.Contains(shortUrl));
        await urlRepository.Add(new Url { ShortUrl = shortUrl, RegularUrl = originalUrl });

        return shortUrl;
    }

     public async Task<string?> GetOriginalUrl(string shortUrl)
    {
        var url = await urlRepository.GetByShortUrl(shortUrl);

        return url.RegularUrl;
    }

   private string MutateUrl(string url)
    {
        var bytes = Encoding.UTF8.GetBytes(url);
        bytes[_random.Next(bytes.Length)] ^= (byte)_random.Next(256);
        
        return Encoding.UTF8.GetString(bytes);
    }

    private static string ToUrlSafeBase64(byte[] bytes)
        => Convert.ToBase64String(bytes)
            .TrimEnd('=')
            .Replace('+', '-')
            .Replace('/', '_');
}