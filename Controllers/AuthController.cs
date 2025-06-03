using ExpenseTrackerAPI.Features.Auth.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand request)
        {
            try
            {
                var token = await _mediator.Send(request);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand request)
        {
            var token = await _mediator.Send(request);
            return Ok(new { Token = token });
        }
    }
}
