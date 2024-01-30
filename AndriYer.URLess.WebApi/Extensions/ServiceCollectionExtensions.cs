using AndriYer.URLess.Application.Contracts;
using AndriYer.URLess.Application.Implementation;
using AndriYer.URLess.Data.Contracts;
using AndriYer.URLess.Data.Implementation;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AndriYer.URLess.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.TryAddScoped<IShortUrlGenerator, ShortUrlGenerator>();
            services.TryAddScoped<IUrlRepository, UrlRepository>();
            
            return services;
        }
    }
}
