using Microsoft.AspNetCore.Mvc;
using TimeSheets.BL.Repositories;
using TimeSheets.DAL.Models;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Route("user/[controller]")]
    public class UserControllers : ControllerBase
    {
        public readonly UserRepository _repository;

        public UserControllers(UserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetAll()
        {
            var res = await _repository.Get();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromQuery] User newUser)
        {
            await _repository.Create(newUser);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update([FromQuery] User newUser)
        {
            await _repository.Update(newUser);
            return NoContent();
        }

        [HttpDelete]
        //[Route("{userId}")]
        public async Task<ActionResult<User>> Delete(int Id)
        {
            await _repository.Delete(Id);
            return NoContent();
        }

    }
}
