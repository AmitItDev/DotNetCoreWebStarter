using Antlr.Runtime.Misc;
using NetFrameworkWebStarter.BAL;
using NetFrameworkWebStarter.Infrastructure;
using NetFrameworkWebStarter.Models;
using NetFrameworkWebStarter.Web.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetFrameworkWebStarter.Web.Controllers
{
    public class AccountController : Controller
    {
        UserManager userManager;
        SettingManager settingManager;
        public AccountController()
        {
            userManager = new UserManager();
            settingManager = new SettingManager();
        }
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string userName, string password)
        {
            if (ModelState.IsValid)
            {
                var model = new UserModel();
                try
                {
                    model = userManager.LoginUser(userName);

                    if (model == null || !model.UserName.ToLower().Equals(userName.ToLower()))
                    {
                        return Json(new object[] { 0, SystemEnum.MessageType.error.ToString(), Messages.InvalidUsername });
                    }
                    if (!model.IsActive)
                    {
                        return Json(new object[] { 0, SystemEnum.MessageType.error.ToString(), Messages.AccountNotActive });
                    }

                    if (password.Equals(EncryptionDecryption.GetDecrypt(model.Password)) && model.IsActive)
                    {
                        ProjectSession.UserName = model.UserName;
                        ProjectSession.UserID = model.UserId;
                        ProjectSession.UserTypeId = model.UserTypeId.Value;
                        ProjectSession.FullName = model.FullName;

                        SettingsModel settings = settingManager.GetSettings();
                        ProjectSession.Settings = settings;
                    }
                    else
                    {
                        return Json(new object[] { 0, SystemEnum.MessageType.error.ToString(), Messages.InvalidCredentials });
                    }

                    return Json(new object[] { 1, SystemEnum.MessageType.success.ToString(), string.Empty, ProjectSession.UserTypeId });
                }
                catch (Exception ex)
                {
                    return Json(new object[] { 0, SystemEnum.MessageType.error.ToString(), ex.Message });
                }
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult Error()
        {
            return View("Error");
        }
        [AllowAnonymous]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction(Actions.Login);
        }

    }
}