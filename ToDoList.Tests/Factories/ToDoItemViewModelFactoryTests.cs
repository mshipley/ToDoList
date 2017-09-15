using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using ToDoList.Data.Entities;
using ToDoList.Overview;
using ToDoList.Tests.Helper;

namespace ToDoList.Factories.Tests
{
    [TestClass()]
    public class ToDoItemViewModelFactoryTests
    {
     

        [TestMethod()]
        public void ProduceTest()
        {

            var factory = new ToDoItemViewModelFactory<TestToDoItemViewModel>();
            var fakeobjects = new FizzWare.NBuilder.Builder().CreateListOfSize<ToDoItem>(50).Build();
            var fakeresults = fakeobjects.Select(o => factory.Produce().Compile().Invoke(o)).ToList();
            for (int i = 0; i < fakeobjects.Count; i++)
            {
                Assert.AreEqual(fakeobjects[i].Task, fakeresults[i].Task);
                Assert.AreEqual(fakeobjects[i].Id, fakeresults[i].Id);
                Assert.AreEqual(fakeobjects[i].Deadline.ToLongDateString(), fakeresults[i].Deadline.ToLongDateString());
                Assert.AreEqual(fakeobjects[i].Completed, fakeresults[i].Completed);
                Assert.AreEqual(fakeobjects[i].MoreDetails, fakeresults[i].MoreDetails);
            }
           
        }


    }
}