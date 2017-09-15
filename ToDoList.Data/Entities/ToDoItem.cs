using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ToDoList.Data.Entities
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }

        public string Task { get; set; }

        public DateTime Deadline { get; set; }

        public bool Completed { get; set; }

        public string MoreDetails { get; set; }
    }
}
