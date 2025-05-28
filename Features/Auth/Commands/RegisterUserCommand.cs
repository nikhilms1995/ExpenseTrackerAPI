using MediatR;

namespace ExpenseTrackerAPI.Features.Auth.Commands
{
    public record RegisterUserCommand(string Email, string Password) :IRequest<string>
    {
    }
}
