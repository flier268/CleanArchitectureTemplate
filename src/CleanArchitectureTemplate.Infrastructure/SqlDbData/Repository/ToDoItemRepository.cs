using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Core.Entities;
using CleanArchitectureTemplate.Core.Interfaces;
using CleanArchitectureTemplate.Infrastructure.Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Infrastructure.SqlDbData.Repository
{
    public class ToDoItemRepository : CosmosDbRepository<ToDoItem>, IToDoItemRepository
    {
        public ToDoItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Use Cosmos DB Parameterized Query to avoid SQL Injection.
        // Get by Category is also an example of single partition read, where get by title will be a cross partition read
        public async Task<IEnumerable<ToDoItem>> GetItemsAsyncByCategory(string category)
        {
            return await Context.ToDoItems.Where(x => x.Category == category).ToListAsync();
        }

        // Use Cosmos DB Parameterized Query to avoid SQL Injection.
        // Get by Title is also an example of cross partition read, where Get by Category will be single partition read
        public async Task<IEnumerable<ToDoItem>> GetItemsAsyncByTitle(string title)
        {
            return await Context.ToDoItems.Where(x => x.Title == title).ToListAsync();
        }
    }
}
