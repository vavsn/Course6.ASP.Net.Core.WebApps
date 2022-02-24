using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TimeSheets.BL.Repositories;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Validation;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Authorize]
    [Route("person/[controller]")]
    public class PersonControllers : ControllerBase
    {
        public readonly PersonRepository _repository;
        public readonly PersonVallidationService _personVallidationService;

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
            var resultValidation = _personVallidationService.Validate(newPerson);
            if(!resultValidation.IsValid)
            {
                var strBadRequest = string.Empty;
                foreach (ValidationFailure error in resultValidation.Errors)
                {
                    OperationFailure failure = new OperationFailure();
                    strBadRequest += "Ошибка в поле: " + error.PropertyName + "\n";
                    strBadRequest += error.ErrorMessage + "\n";
                    strBadRequest += "Код ошибки: " + error.ErrorCode + "\n";
                }
                return BadRequest(strBadRequest);
            }
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
        public async Task<ActionResult<Person>> Delete([Range(1, int.MaxValue)] int Id)
        {
            await _repository.Delete(Id);
            return NoContent();
        }

    }
}
