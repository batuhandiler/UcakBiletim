using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UcakBiletim.Business.Services.Users;
using UcakBiletim.Entities.Concrete;

namespace UcakBiletim.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> AddUser(User user)
        {
            if (user != null)
            {
                await _userService.AddAsync(user);
                return Ok();
            }
            else
                return BadRequest();
        }
    }
}
