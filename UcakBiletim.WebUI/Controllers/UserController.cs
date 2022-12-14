using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UcakBiletim.Business.Services.Users;
using UcakBiletim.Entities.Concrete;
using UcakBiletim.WebUI.CustomExtensions;

namespace UcakBiletim.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> SignUp(User user)
        {
            if (!string.IsNullOrEmpty(user.Mail) && !string.IsNullOrEmpty(user.Password))
            {
                try
                {
                    var userExist = await _userService.IsUserExist(user);
                    if (userExist)
                        return BadRequest("UserExists");

                    await _userService.AddAsync(user);
                    return Ok();
                }
                catch (Exception exception)
                {
                    return BadRequest();
                }
            }
            else
                return BadRequest();
        }

        public async Task<IActionResult> SignIn(User user)
        {
            if (!string.IsNullOrEmpty(user.Mail) && !string.IsNullOrEmpty(user.Password))
            {
                try
                {
                    var isUserCanSignIn = await _userService.IsUserCanSignIn(user);
                    if (isUserCanSignIn)
                    {
                        var signInUser = await _userService.GetUserAsync(user);
                        HttpContext.Session.Set<User>("User", signInUser);
                        HttpContext.Session.SetString("UserMail", signInUser.Mail);
                        HttpContext.Session.SetString("UserName", signInUser.Name);
                        HttpContext.Session.SetString("UserSurname", signInUser.SurName);
                        return Ok();
                    }
                    else
                        return BadRequest("MailOrPasswordWrong");
                }
                catch (Exception exception)
                {
                    return BadRequest();
                }
            }
            else
                return BadRequest("MailOrPasswordWrong");
        }

        public IActionResult SignOut()
        {
            try
            {
                var user = HttpContext.Session.Get<User>("User");

                if (user != null)
                {
                    HttpContext.Session.Set<User>("User", null);
                    HttpContext.Session.SetString("UserMail", "");
                    HttpContext.Session.SetString("UserName", "");
                    HttpContext.Session.SetString("UserSurname", "");
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch (Exception exception)
            {
                return BadRequest();
            }
        }

        public IActionResult GetSignUpPartial()
        {
            return PartialView("~/Views/Shared/Partials/_SignUp.cshtml");
        }

        public IActionResult GetSignInPartial()
        {
            return PartialView("~/Views/Shared/Partials/_SignIn.cshtml");
        }
    }
}
