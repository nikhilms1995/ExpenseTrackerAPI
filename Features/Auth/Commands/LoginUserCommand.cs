using MediatR;

namespace ExpenseTrackerAPI.Features.Auth.Commands
{
    public record LoginUserCommand(string Email, string Password) : IRequest<string>
    { }
}