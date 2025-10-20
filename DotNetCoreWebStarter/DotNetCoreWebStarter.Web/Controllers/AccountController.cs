using DotNetCoreWebStarter.Core.Entities;
using DotNetCoreWebStarter.Core.Services;
using DotNetCoreWebStarter.Data;
using DotNetCoreWebStarter.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebStarter.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var user = await _userManager.FindByNameAsync(model.Username);
                user = user == null ? await _userManager.FindByEmailAsync(model.Username) : user;
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("General", "Invalid username or password");
            }
            catch (Exception ex)
            {
                ErrorLogService.Log(ex);
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch (Exception ex)
            {
                ErrorLogService.Log(ex);
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
