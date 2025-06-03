using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenseTrackerAPI.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected Guid? UserId
        {
            get
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return Guid.TryParse(userIdClaim, out var userId) ? userId : null;
            }
        }
    }
}
