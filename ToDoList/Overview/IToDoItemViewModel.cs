using System;

namespace ToDoList.Overview
{
    public interface IToDoItemViewModel
    {
        int Id { get; set; }
        string Task { get; set; }
        DateTime Deadline { get; set; }
        bool Completed { get; set; }
        string MoreDetails { get; set; }
    }
}