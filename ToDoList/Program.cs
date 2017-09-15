using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using ToDoList.Data;
using ToDoList.Data.Entities;
using ToDoList.Factories;
using ToDoList.Overview;
using ToDoList.Repositories;
using ToDoList.Repositories.Abstract;

namespace ToDoList
{
    static class Program
    {
        [STAThread]
         static void Main()
        {
            var container = ContainerHelper.Container;

            // Any additional other configuration, e.g. of your desired MVVM toolkit.

            RunApplication(container);
        }

        

        private static void RunApplication(Container container)
        {
            try
            {
                var app = new App();
                var mainWindow = container.GetInstance<MainWindow>();
                app.Run(mainWindow);
            }
            catch (Exception ex)
            {
                //Log the exception and exit
            }
        }
    }
}
