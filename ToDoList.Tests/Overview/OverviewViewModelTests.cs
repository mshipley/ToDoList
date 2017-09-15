using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Overview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FizzWare.NBuilder;
using NSubstitute;
using ToDoList.Data.Entities;
using ToDoList.Factories;
using ToDoList.Repositories;
using ToDoList.Tests.Helper;

namespace ToDoList.Overview.Tests
{
    [TestClass()]
    public class OverviewViewModelTests
    {
        [TestMethod()]
        public void OverviewViewModelTest()
        {
            //setup
            var mockRepository = NSubstitute.Substitute.For<IToDoItemRepository>();
            var fakeToDoItems = Builder<ToDoItem>.CreateListOfSize(100).Build();
            mockRepository.Get().ReturnsForAnyArgs(fakeToDoItems.AsQueryable());
            var factory = new ToDoItemViewModelFactory<TestToDoItemViewModel>();
            var ovModel = new OverviewViewModel<TestToDoItemViewModel>(mockRepository, factory);

            var testEntity = new ToDoItem()
            {
                Id = -99,
                Task = "This is a test",
                MoreDetails = "This is more details test",
                Deadline = DateTime.Now,
                Completed = true

            };
            mockRepository.Create(testEntity).ReturnsForAnyArgs(testEntity);

            //setup and act
            var testViewModel = new ToDoItemViewModel(mockRepository)
            {
                Task = "This is a test",
                MoreDetails = "This is more details test",
                Deadline = DateTime.Now,
                Completed = true

            };


            //Assert

            Assert.AreEqual(ovModel.ToDoItems.Count, 100);
            for (int i = 0; i < fakeToDoItems.Count; i++)
            {
                Assert.AreEqual(ovModel.ToDoItems[i].Task, fakeToDoItems[i].Task);
                Assert.AreEqual(ovModel.ToDoItems[i].Completed, fakeToDoItems[i].Completed);
                Assert.AreEqual(ovModel.ToDoItems[i].Deadline, fakeToDoItems[i].Deadline);
                Assert.AreEqual(ovModel.ToDoItems[i].Id, fakeToDoItems[i].Id);
                Assert.AreEqual(ovModel.ToDoItems[i].MoreDetails, fakeToDoItems[i].MoreDetails);
            }


            mockRepository.ReceivedWithAnyArgs(1).Get();

            //Create Test 
            mockRepository.ReceivedWithAnyArgs(0).Create(Arg.Any<ToDoItem>());
            ((ICommand)ovModel.CreateCommand).Execute(testViewModel);
            mockRepository.ReceivedWithAnyArgs(1).Create(Arg.Any<ToDoItem>());
            mockRepository.ReceivedWithAnyArgs(2).Get();

            //Delete Test
            mockRepository.ReceivedWithAnyArgs(0).Delete(Arg.Any<int>());
            ((ICommand)ovModel.DeleteCommand).Execute(-99);
            mockRepository.ReceivedWithAnyArgs(1).Delete(Arg.Any<int>());
            mockRepository.ReceivedWithAnyArgs(2).Get();



        }
    }
}