using CleanArchitectureTemplate.Core.Interfaces.Storage;
using CleanArchitectureTemplate.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Storage.Net;

namespace CleanArchitectureTemplate.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        ///     Setup Azure Blob storage
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void SetupStorage(this IServiceCollection services, IConfiguration configuration)
        {
            StorageFactory.Modules.UseAzureBlobStorage();

            // Register IBlobStorage, which is used in AzureBlobStorageService
            // Avoid using IBlobStorage directly outside of AzureBlobStorageService.
            services.AddScoped<Storage.Net.Blobs.IBlobStorage>(
                factory => StorageFactory.Blobs.FromConnectionString(configuration.GetConnectionString("StorageConnectionString")));

            services.AddScoped<IStorageService, AzureBlobStorageService>();
        }

    }
}
