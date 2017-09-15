using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data.Entities;
using ToDoList.Overview;

namespace ToDoList.Factories
{
    public class ToDoItemViewModelFactory<T> : IFactory<ToDoItem, T> where T : IToDoItemViewModel, new()
    {


       public Expression<Func<ToDoItem, T>> Produce() 
        {
            return toDoItem =>

               new T()
               {
                   Task = toDoItem.Task,
                   Deadline = toDoItem.Deadline,
                   Completed = toDoItem.Completed,
                   Id = toDoItem.Id,
                   MoreDetails = toDoItem.MoreDetails,
               };
            
        }

      
    }
}
