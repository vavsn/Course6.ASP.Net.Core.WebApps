using Microsoft.AspNetCore.Mvc;
using TimeSheets.BL.Repositories;
using TimeSheets.DAL.Models;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Route("bankaccount/[controller]")]
    public class BankAccountControllers : ControllerBase
    {
        public readonly BankAccountRepository _repository;

        public BankAccountControllers(BankAccountRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<BankAccount>> GetAll()
        {
            var res = await _repository.Get();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<BankAccount>> Create()
        {
            await _repository.Add();
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<BankAccount>> Operation([FromBody] BankAccount ba)
        {
            await _repository.Operation(ba);
            return NoContent();
        }


        [HttpDelete]
        public async Task<ActionResult<BankAccount>> Close([FromBody] BankAccount ba)
        {
            await _repository.Close(ba);
            return NoContent();
        }

    }
}
