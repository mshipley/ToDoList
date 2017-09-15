using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Repositories.Abstract
{
    public interface IDeleteRepository<T,TT>
    {
        TT Delete(T input);
    }
}
