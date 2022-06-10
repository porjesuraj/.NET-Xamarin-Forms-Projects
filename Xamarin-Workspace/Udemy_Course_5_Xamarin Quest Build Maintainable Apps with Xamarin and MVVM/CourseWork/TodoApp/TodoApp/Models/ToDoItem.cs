using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Models
{
   public class ToDoItem
    {
        public string Name { get; set; }

        public bool IsCompleted { get; set; }

        public ToDoItem(string name)
        {
            Name = name;

        }

        public static List<ToDoItem> GetToDoItems()
        {
            return new List<ToDoItem>
            {
                new ToDoItem("Work From Home"),
                new ToDoItem("Work From Goa"),
                new ToDoItem("Lunch Time"),
                new ToDoItem("Do Yoga "),
                new ToDoItem("Go out fro Cycling")
            }; 

        }
    }
}
