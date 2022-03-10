using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheet.API.Models;
using TimeSheets.BL.Services;
using TimeSheets.DAL.Interfaces;

namespace TimeSheet.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonService<Person> repository;

        public PersonController(IPersonService<Person> repository)
        {
            this.repository = repository;
        }
        [HttpGet("/persons/{id}")]
        public IActionResult GetById([FromRoute] int id) // FromRoute
        {
            Person pers = repository.GetById(id);

            return Ok();
        }

        [HttpGet("/persons/search?searchTerm={term}")]
        public IActionResult GetByName([FromQuery] string term) // FromQuery
        {
            Person pers = repository.GetByName(term);

            return Ok();
        }

        [HttpGet("/persons/?skip={5}&take={10}")]
        public async Task<ActionResult<IReadOnlyCollection>> GetList([FromQuery] int skip, [FromQuery] int take)
        {
            Person pers = repository.GetByName(term);

            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person pers) // FromBody
        {
            repository.Create(pers);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromRoute] int id) // FromRoute
        {
            repository.Delete(id);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromRoute] Person pers) // FromRoute
        {
            repository.Update(pers);

            return Ok();
        }

    }
}
