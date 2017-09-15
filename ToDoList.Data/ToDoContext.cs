
using System;
using System.Data.Entity;
using ToDoList.Data.Entities;

namespace ToDoList.Data
{
    public class ToDoContext : DbContext, IToDoContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
