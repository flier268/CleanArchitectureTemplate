using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Core.Entities.Base;
using CleanArchitectureTemplate.Core.Interfaces;
using CleanArchitectureTemplate.Infrastructure.Identity.Models;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Infrastructure.SqlDbData.Repository
{
    public abstract class CosmosDbRepository<T> : IRepository<T> where T : BaseEntity
    {
        public CosmosDbRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        public async Task AddItemAsync(T item)
        {
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(string id)
        {
            T item = await Context.FindAsync<T>(id);
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }

        public async Task<T> GetItemAsync(string id)
        {
            return await Context.FindAsync<T>(id);
        }

        // Search data using SQL query string
        // This shows how to use SQL string to read data from Cosmos DB for demonstration purpose.
        // For production, try to use safer alternatives like Parameterized Query and LINQ if possible.
        // Using string can expose SQL Injection vulnerability, e.g. select * from c where c.id=1 OR 1=1. 
        // String can also be hard to work with due to special characters and spaces when advanced querying like search and pagination is required.
        public async Task<IEnumerable<T>> GetItemsAsync(string queryString)
        {
            return await Context.Set<T>().FromSqlRaw(queryString).ToListAsync();
        }

        /// <inheritdoc cref="IRepository{T}.GetItemsAsync(ISpecification{T})"/>
        public async Task<IEnumerable<T>> GetItemsAsync(ISpecification<T> specification)
        {
            IQueryable<T> queryable = ApplySpecification(specification);
            return await queryable.ToListAsync();
        }

        /// <inheritdoc cref="IRepository{T}.GetItemsCountAsync(ISpecification{T})"/>
        public async Task<int> GetItemsCountAsync(ISpecification<T> specification)
        {
            IQueryable<T> queryable = ApplySpecification(specification);
            return await queryable.CountAsync();
        }

        public async Task UpdateItemAsync(string id, T item)
        {
            Context.Update(item);
            await Context.SaveChangesAsync();
        }

        /// <summary>
        ///     Evaluate specification and return IQueryable
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator.Default.GetQuery(Context.Set<T>().AsQueryable(), specification);
        }
    }
}
