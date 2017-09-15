using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Repositories.Abstract
{
    public interface IUpdateRepository<TId,TAction,TResult>
    {
        TResult Update(TId id,TAction action);
    }
}
