using HolidayManagement.Helpers;
using HolidayManagement.Models;
using HolidayManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HolidayManagement.Controllers
{
    [ApiController]
    public class AccountController : Controller
    {
        private List<User> users;
        private List<Role> roles;
        private List<UserInstitution> userInstitutions;

        public AccountController(IModelService<User> userService, IModelService<Role> roleService, IModelService<UserInstitution> userInstitutionService) {
            users = userService.GetAll().Result;
            roles = roleService.GetAll().Result;
            userInstitutions = userInstitutionService.GetAll().Result;
        }

        [HttpPost("/Account/Login")]
        public async Task<IActionResult> Login([FromForm] string username, [FromForm] string password, [FromForm] string institutionId)
        {
            var u = users.FirstOrDefault(x => x.Username == username);
            if (u is null || !new PasswordManager().Verify(password, u.Password))
            {
                return Ok(new { success = false, message = "Invalid Username or Password" });
            }

            var role = userInstitutions.FirstOrDefault(x => x.UserId == u.Id && x.InstitutionId == Guid.Parse(institutionId)).RoleId;
            var claims = new List<Claim>
                {
                    new Claim("ID", u.Id.ToString()),
                    new Claim(ClaimTypes.Name, u.Username),
                    new Claim(ClaimTypes.Role, roles.Single(x => x.Id == role).Name)
                };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);
            return Ok(new { success = true });
        }

        [HttpPost("/Account/Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(new { success = true });
        }
    }
}
