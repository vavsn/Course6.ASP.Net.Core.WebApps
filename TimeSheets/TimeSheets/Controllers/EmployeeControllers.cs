using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TimeSheets.BL.Repositories;
using TimeSheets.DAL.Models;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Authorize]
    [Route("employee/[controller]")]
    public class EmployeeControllers : ControllerBase
    {
        public readonly EmployeeRepository _repository;

        public EmployeeControllers(EmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Employee>> GetAll()
        {
            var res = await _repository.Get();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Create([FromBody] Employee newEmp)
        {
            await _repository.Add(newEmp);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> Update([FromBody] Employee newEmp)
        {
            await _repository.Update(newEmp);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Employee>> Delete([Range(1, int.MaxValue)] int Id)
        {
            await _repository.Delete(Id);
            return NoContent();
        }

    }
}
