using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using ToDoList.Data;
using ToDoList.Data.Entities;
using ToDoList.Factories;
using ToDoList.Overview;
using ToDoList.Repositories;
using ToDoList.Repositories.Abstract;

namespace ToDoList
{
    public static class ContainerHelper
    {
       
        static ContainerHelper()
        {
            
            Container = new Container();


            Container.Register<IToDoContext,ToDoContext > (Lifestyle.Singleton);
            Container.Register<IToDoItemRepository, ToDoItemRepository>();
           Container.Register<IFactory<ToDoItem, ToDoItemViewModel>, ToDoItemViewModelFactory<ToDoItemViewModel>>();

            Container.Register<MainWindow>();


            Container.Register<OverviewViewModel<ToDoItemViewModel>>();

            Container.Verify();

        }
      

        public static Container Container;
    }
}
