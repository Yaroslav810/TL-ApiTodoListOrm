using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Entities;

namespace TodoList
{
    public class ToDoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }

        public ToDoDto()
        {  }

        public ToDoDto( ToDoEntity toDoEntity )
        {
            Id = toDoEntity.Id;
            Name = toDoEntity.Name;
            Done = toDoEntity.Done;
        }

        public void CopyTo( ToDoEntity toDoEntity )
        {
            toDoEntity.Name = Name;
            toDoEntity.Done = Done;
        }
    }
}
