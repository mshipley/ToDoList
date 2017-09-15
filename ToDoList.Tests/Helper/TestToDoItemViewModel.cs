using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Overview;

namespace ToDoList.Tests.Helper
{
    public class TestToDoItemViewModel:IToDoItemViewModel
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public DateTime Deadline { get; set; }
        public bool Completed { get; set; }
        public string MoreDetails { get; set; }
    }
}
