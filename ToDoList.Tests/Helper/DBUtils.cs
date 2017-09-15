using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace ToDoList.Tests.Helper
{
   public static class DBUtils
    {
        public static DbSet<T> FakeDbSet<T>(List<T> data) where T : class
        {
            var _data = data.AsQueryable();
            var fakeDbSet = Substitute.For<DbSet<T>, IQueryable<T>>();
            ((IQueryable<T>)fakeDbSet).Provider.Returns(_data.Provider);
            ((IQueryable<T>)fakeDbSet).Expression.Returns(_data.Expression);
            ((IQueryable<T>)fakeDbSet).ElementType.Returns(_data.ElementType);
            ((IQueryable<T>)fakeDbSet).GetEnumerator().Returns(_data.GetEnumerator());

            fakeDbSet.AsNoTracking().Returns(fakeDbSet);

            return fakeDbSet;
        }
    }
}
