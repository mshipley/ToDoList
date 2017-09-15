using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Factories
{
    public interface IFactory<T,TT>
    {
        Expression<Func<T,TT>> Produce();
    }
}
