using System;
using CleanArchitectureTemplate.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Infrastructure.Identity.Models
{
    public partial class ApplicationDbContext
    {
        // for checking that DI is getting a different instance each time when the dbcontext is injected in the context of a web request
        private Guid _instanceId = Guid.NewGuid();
        public DbSet<ToDoItem> ToDoItems { get; set; } = null!;


        public static void AddBaseOptions(DbContextOptionsBuilder<ApplicationDbContext> builder, string connectionString)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string must be provided", nameof(connectionString));

            builder.UseSqlServer(connectionString, x =>
            {
                x.EnableRetryOnFailure();
            });
        }

        public static void AddBaseOptions(DbContextOptionsBuilder builder, string connectionString)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string must be provided", nameof(connectionString));

            builder.UseSqlServer(connectionString, x =>
            {
                x.EnableRetryOnFailure();
            });
        }
    }
}
