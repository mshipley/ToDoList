using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Overview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using NSubstitute;
using ToDoList.Data.Entities;
using ToDoList.Repositories;

namespace ToDoList.Overview.Tests
{
    [TestClass()]
    public class ToDoItemViewModelTests
    {
        [TestMethod()]
        public void ToDoItemViewModelTest()
        {
            var mockRepository = NSubstitute.Substitute.For<IToDoItemRepository>();
            var toDoItemViewModel=new ToDoItemViewModel(mockRepository);

            toDoItemViewModel.Deadline=DateTime.Now.AddMinutes(1);
            Assert.IsFalse(toDoItemViewModel.HasExpired);
            Assert.AreEqual(((SolidColorBrush)toDoItemViewModel.BackgroundColor).Color, new SolidColorBrush(Colors.Transparent).Color);

            toDoItemViewModel.Deadline = DateTime.Now.AddDays(-1);
            Assert.IsTrue(toDoItemViewModel.HasExpired);
            Assert.AreNotEqual(((SolidColorBrush)toDoItemViewModel.BackgroundColor).Color, new SolidColorBrush(Colors.Transparent).Color);

            mockRepository.ReceivedWithAnyArgs(0).Update(Arg.Any<int>(),Arg.Any<Action<ToDoItem>>());
            ((ICommand)toDoItemViewModel.UpdateCommand).Execute(null);
            mockRepository.ReceivedWithAnyArgs(1).Update(Arg.Any<int>(), Arg.Any<Action<ToDoItem>>());

        }
    }
}