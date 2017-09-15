using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Repositories.Abstract
{
    public interface ICreateRepository<T,TT>
    {
        TT Create(T input);
    }
}
