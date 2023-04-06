using Automarket.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.ViewModels.Account
{
    public class UserWithTokenViewModel
    {
        public string Token { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public UserWithTokenViewModel(User user, string token)
        {
            Id = user.Id.ToString();
            Name = user.Name;
            Email = user.Email;
            Role = user.Role.ToString();
            Token = token;
        }
    }
}
