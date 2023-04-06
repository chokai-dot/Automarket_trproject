using Automarket.Domain.Entity;
using Automarket.Domain.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Service.Interfaces
{
    public interface IUserService
    {
        Task<
            User> RegisterUserAsync(RegistrationViewModel registrationViewModel);
        Task<string> AuthenticateAsync(LoginViewModel loginViewModel);
    }
}
