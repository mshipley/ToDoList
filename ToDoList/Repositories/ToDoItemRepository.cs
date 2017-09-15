using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Data.Entities;
using ToDoList.Repositories.Abstract;

namespace ToDoList.Repositories
{
    public interface IToDoItemRepository : IReadRepository<IQueryable<ToDoItem>>,
        ICreateRepository<ToDoItem, ToDoItem>,
        IDeleteRepository<int, int>,
        IUpdateRepository<int,Action<ToDoItem>,ToDoItem>
    {
    }

    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly IToDoContext _toDoContext;
        public ToDoItemRepository(IToDoContext toDoContext)
        {
            _toDoContext = toDoContext;
        }
        public IQueryable<ToDoItem> Get()
        {
            return _toDoContext.ToDoItems.OrderBy(t => t.Deadline);
        }

        public ToDoItem Create(ToDoItem input)
        {
            _toDoContext.ToDoItems.Add(input);
            _toDoContext.SaveChanges();
            return input;
        }

        public int Delete(int input)
        {
            _toDoContext.ToDoItems.Remove(_toDoContext.ToDoItems.Find(input));
            return _toDoContext.SaveChanges();
        }


        public ToDoItem Update(int id, Action<ToDoItem> action)
        {
            action.Invoke(_toDoContext.ToDoItems.Find(id));
            _toDoContext.SaveChanges();
            return _toDoContext.ToDoItems.Find(id);
        }
    }
}
