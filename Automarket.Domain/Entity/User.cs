using Automarket.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Automarket.Domain.Entity
{
    public class User
    {
       
            public int Id { get; set; }

            [Required]
            [StringLength(50)]
            public string Name { get; set; }

            [Required]
            [StringLength(100)]
            public string Email { get; set; }

            [Required]
            [StringLength(50)]
            public string Password { get; set; }

            public Role Role { get; set; } = Role.User;
      
        
    }
}
