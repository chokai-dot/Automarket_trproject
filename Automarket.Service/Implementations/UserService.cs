using System;
using System.Threading.Tasks;
using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.ViewModels.Account;
using Automarket.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Automarket.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IJwtService _jwtService;

        public UserService(IBaseRepository<User> userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
        }

        public async Task<User> RegisterUserAsync(RegistrationViewModel registrationViewModel)
        {
            var existingUser = await _userRepository.GetAll().FirstOrDefaultAsync(u => u.Email == registrationViewModel.Email);
            if (existingUser != null)
            {
                throw new ApplicationException("User with the same email already exists");
            }
            if (registrationViewModel.Password != registrationViewModel.PasswordConfirm)
            {
                throw new ApplicationException("Password and Confirm password do not match");
            }
            var user = new User
            {
                Name = registrationViewModel.Name,
                Email = registrationViewModel.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registrationViewModel.Password),
                Role = Role.User
            };

            await _userRepository.Create(user);

            return user;
        }

        public async Task<string> AuthenticateAsync(LoginViewModel loginViewModel)
        {
            var user = await _userRepository.GetAll().SingleOrDefaultAsync(u => u.Email == loginViewModel.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginViewModel.Password, user.Password))
            {
                return null;
            }

            var token = _jwtService.GenerateToken(user);

            return token;
        }
    }
}
