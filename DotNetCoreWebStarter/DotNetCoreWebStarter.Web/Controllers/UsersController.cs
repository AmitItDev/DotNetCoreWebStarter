using DotNetCoreWebStarter.Core.Entities;
using DotNetCoreWebStarter.Core.Interfaces;
using DotNetCoreWebStarter.Core.Models.Users;
using DotNetCoreWebStarter.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DotNetCoreWebStarter.Web.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var roles = await _userService.GetRolesAsync();
                ViewBag.Roles = roles;
                ViewBag.Statuses = new List<string> { "Active", "Inactive" };

            }
            catch (Exception ex)
            {
                ErrorLogService.Log(ex);
            }
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsers([FromBody] UserFilterRequest filter)
        {
            try
            {
                var result = await _userService.GetUsersAsync(filter);
                return Json(result);
            }
            catch (Exception ex)
            {
                ErrorLogService.Log(ex);
            }
            return Json(null);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Manage(int? id)
        {
            try
            {
                var model = await _userService.GetUserForManageAsync(id);
                return View(model);
            }
            catch (Exception ex)
            {
                ErrorLogService.Log(ex);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Manage(UserManageViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model = await _userService.GetUserForManageAsync(model.UserId);
                    return View(model);
                }

                var success = await _userService.ManageUserAsync(model);
                if (!success.Item1)
                {
                    ModelState.AddModelError("General", success.Item2);
                    model = await _userService.GetUserForManageAsync(model.UserId);
                    return View(model);
                }

                TempData["SuccessMessage"] = model.UserId.HasValue ? "User updated successfully!" : "User created successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("General", ex.Message);
                ErrorLogService.Log(ex);
            }
            return View(model);
        }

        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> Delete([FromBody] DeleteUserRequest id)
        //if we have object then send the data from js like from fetch and set body: JSON.stringify({ id: user.userId })

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            try
            {
                var result = await _userService.DeleteUserAsync(id);
                if (!result.Item1)
                    return Json(new { success = false, message = result.Item2 });

                return Json(new { success = true, message = "User deleted successfully." });
            }
            catch (Exception ex)
            {
                ErrorLogService.Log(ex);
                return Json(new { success = false, message = "Error deleting user: " + ex.Message });
            }
        }

    }
}
