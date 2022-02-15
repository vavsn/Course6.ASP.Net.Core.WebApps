using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.API.Models;
using TimeSheets.BL.Services;

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
        public IActionResult GetByName([FromRoute] string term) // FromRoute
        {
            Person pers = repository.GetByName(term);

            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromRoute] Person pers) // FromRoute
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
