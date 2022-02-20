using Microsoft.AspNetCore.Mvc;
using TimeSheets.BL.Repositories;
using TimeSheets.DAL.Models;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Route("person/[controller]")]
    public class PersonControllers : ControllerBase
    {
        public readonly PersonRepository _repository;

        public PersonControllers(PersonRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Person>> GetAll()
        {
            var res = await _repository.Get();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> Create([FromBody] Person newPerson)
        {
            await _repository.Add(newPerson);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Person>> Update([FromBody] Person newPerson)
        {
            await _repository.Update(newPerson);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Person>> Delete(int Id)
        {
            await _repository.Delete(Id);
            return NoContent();
        }

    }
}
