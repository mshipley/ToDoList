using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Repositories.Abstract
{
   public interface IReadRepository<T,TT>
   {
       TT Get(T input);
   }

    public interface IReadRepository<TT>
    {
        TT Get();
    }
}
