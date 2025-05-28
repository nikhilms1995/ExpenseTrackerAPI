using ExpenseTrackerAPI.Domain.Entites;
using ExpenseTrackerAPI.Domain.Interfaces;
using ExpenseTrackerAPI.Features.Auth.Commands;
using ExpenseTrackerAPI.Infrastructure.Data;
using ExpenseTrackerAPI.Infrastructure.Services;
using MediatR;

namespace ExpenseTrackerAPI.Features.Auth.Handlers
{
    public class RegisterUserHandler :IRequestHandler<RegisterUserCommand,string>
    {
        private readonly JwtTokenService _jwtTokenService;
        private readonly IUserRepository _userRepository;
        
        public RegisterUserHandler(JwtTokenService jwtTokenService,IUserRepository userRepository)
        {
            _jwtTokenService = jwtTokenService ?? throw new ArgumentNullException(nameof(jwtTokenService));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }
       
        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);
            if (existingUser != null)
                throw new Exception("User already exists.");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = new User
            {
                Email = request.Email,
                PasswordHash = passwordHash
            };

            await _userRepository.RegisterUserAsync(user);
            return _jwtTokenService.GenerateToken(user);
        }
    }
}
