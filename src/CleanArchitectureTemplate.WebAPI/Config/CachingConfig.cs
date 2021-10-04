using CleanArchitectureTemplate.Core.Interfaces;
using CleanArchitectureTemplate.WebAPI.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureTemplate.WebAPI.Config
{
    /// <summary>
    ///     Setup caching
    /// </summary>
    public static class CachingConfig
    {
        /// <summary>
        ///     In-memory Caching
        /// </summary>
        /// <param name="services"></param>
        public static void SetupInMemoryCaching(this IServiceCollection services)
        {
            // Non-distributed in-memory cache services
            services.AddMemoryCache();
            services.AddScoped<ICachedToDoItemsService, InMemoryCachedToDoItemsService>();
        }
    }
}
