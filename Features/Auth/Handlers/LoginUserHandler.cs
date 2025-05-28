using ExpenseTrackerAPI.Domain.Interfaces;
using ExpenseTrackerAPI.Features.Auth.Commands;
using ExpenseTrackerAPI.Infrastructure.Repositories;
using ExpenseTrackerAPI.Infrastructure.Services;
using MediatR;

namespace ExpenseTrackerAPI.Features.Auth.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtTokenService _jwtTokenService;

        public LoginUserHandler(IUserRepository userRepository, JwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new Exception("Invalid credentials");

            return _jwtTokenService.GenerateToken(user);
        }
    }
}
