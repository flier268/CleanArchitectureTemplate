using System.Collections.Generic;
using CleanArchitectureTemplate.Core.Entities;

namespace CleanArchitectureTemplate.Core.Interfaces
{
    public interface ICachedToDoItemsService
    {
        IEnumerable<ToDoItem> GetCachedToDoItems();
        void DeleteCachedToDoItems();
        void SetCachedToDoItems(IEnumerable<ToDoItem> entry);
    }
}
