using CQRS_Users.Commands;
using CQRS_Users.Models;
using CQRS_Users.Models.DTOs;
using CQRS_Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Users.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator) => _mediator = mediator;

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query);

            if(result is null) return NotFound();

            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] UserDto model)
        {
            var command = new AddUserCommand(model);
            var result = await _mediator.Send(command);
            
            if(result) return Ok();

            return BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UserModel model)
        {
            var command = new UpdateUserCommand(model);
            var result = await _mediator.Send(command);

            if(result) return Ok();

            return BadRequest();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);

            if(result) return Ok();

            return BadRequest();
        }
    }
}
