using Microsoft.AspNetCore.Mvc;
using TimeSheets.BL.Repositories;
using TimeSheets.DAL.Models;

namespace TimeSheets.Controllers
{
    [ApiController]
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
        public async Task<ActionResult<Employee>> Create([FromQuery] Employee newEmp)
        {
            await _repository.Create(newEmp);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> Update([FromQuery] Employee newEmp)
        {
            await _repository.Update(newEmp);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Employee>> Delete(int Id)
        {
            await _repository.Delete(Id);
            return NoContent();
        }

    }
}
