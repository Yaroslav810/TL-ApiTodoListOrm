using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Entities;
using TodoList.Infrastructure;

namespace TodoList
{
    public interface IToDoRepository
    {
        List<ToDoDto> GetAll();
        int Create(ToDoDto toDoDto);
        void Update(int id, ToDoDto toDoDto);
    }

    public class ToDoRepository : IToDoRepository
    {
        private class ToDo
        {
            public int Id { get; }
            public string Name { get; set; }
            public bool Done { get; set; }

            public DateTime creationDate { get; }

            public ToDo(int id, string name, bool done)
            {
                Id = id;
                Name = name;
                Done = done;
                creationDate = DateTime.Now;
            }
        }

        readonly ToDoDbContext _context;
        readonly IUnitOfWork _unitOfWork;

        public ToDoRepository( ToDoDbContext context, IUnitOfWork unitOfWork )
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public List<ToDoDto> GetAll() => _context.Set<ToDoEntity>().ToList().Select( item => new ToDoDto( item ) ).ToList();

        public int Create( ToDoDto toDoDto )
        {
            ToDoEntity newEntity = new ToDoEntity();
            toDoDto.CopyTo( newEntity );
            _context.Set<ToDoEntity>().Add( newEntity );
            _unitOfWork.Commit();
            return newEntity.Id;
        }

        public void Update( int id, ToDoDto toDoDto )
        {
            ToDoEntity foundEntity = _context.Set<ToDoEntity>().SingleOrDefault( item => item.Id == id );
            toDoDto.CopyTo( foundEntity );
            _unitOfWork.Commit();
        }
    }
}
