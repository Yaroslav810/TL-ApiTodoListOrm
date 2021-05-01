using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoController( IToDoRepository toDoRepository )
        {
            _toDoRepository = toDoRepository;
        }

        // GET: api/<ToDoController>
        [HttpGet]
        public List<ToDoDto> Get()
        {
            return _toDoRepository.GetAll();
        }

        // POST api/<ToDoController>
        [HttpPost]
        public int Post([FromBody] ToDoDto toDoDto)
        {
            return _toDoRepository.Create(toDoDto);
        }

        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ToDoDto toDoDto)
        {
            _toDoRepository.Update(id, toDoDto);
        }
    }
}
