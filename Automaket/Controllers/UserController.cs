using Automarket.Domain.Entity;
using Automarket.Domain.ViewModels.Account;
using Automarket.Service.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Automarket.Controllers
{
    public class UserController : Controller
    {

        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegistrationViewModel model)
        {
            try
            {
                var user = await _userService.RegisterUserAsync(model);
                return RedirectToAction("Index", "Home");
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginViewModel model)
        {
            var token = await _userService.AuthenticateAsync(model);
            if (token == null)
            {
                return Unauthorized();
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
