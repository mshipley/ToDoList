using System.Data.Entity;
using ToDoList.Data.Entities;

namespace ToDoList.Data
{
    public interface IToDoContext
    {
        DbSet<ToDoItem> ToDoItems { get; set; }
        int SaveChanges();
    }
}