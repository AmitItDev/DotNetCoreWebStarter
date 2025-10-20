using BizsoftProjectNetFramework.BAL;
using BizsoftProjectNetFramework.Infrastructure;
using BizsoftProjectNetFramework.Models;
using DataTables.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BizsoftProjectNetFramework.Web.Controllers
{
    public class UsersController : Controller
    {
        UserManager userManager;
        private readonly DropdownManager _dropdownManager;
        public UsersController()
        {
            userManager = new UserManager();
            _dropdownManager = new DropdownManager();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GetUserData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string searchString = null)
        {
            var model = userManager.GetUserData(requestModel, searchString);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Manage(string uid)
        {
            var model = new UserModel();
            try
            {
                if (!string.IsNullOrEmpty(uid))
                {
                    int userId = Convert.ToInt32(ConvertTo.Base64Decode(uid));
                    if (userId > 0)
                    {
                        model = userManager.GetUserByID(userId);
                    }
                }
                else
                {
                    model.IsActive = true;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
            }
            finally
            {
                ViewBag.UserTypeList = _dropdownManager.GetUserTypeList();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Manage(UserModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool status = userManager.AddEditUser(model);

                    if (status)
                    {
                        if (model.UserId == 0)
                        {
                            ViewBag.Message = new object[] { SystemEnum.MessageType.success.ToString(), Messages.RecordSavedSuccessfully };
                            TempData["SuccessMessage"] = Messages.RecordSavedSuccessfully;
                            return RedirectToAction(Class.Actions.Index, Class.Controllers.Users);
                        }
                        else if (model.UserId > 0)
                        {
                            ViewBag.Message = new object[] { SystemEnum.MessageType.success.ToString(), Messages.RecordUpdatedSuccessfully };
                            TempData["SuccessMessage"] = Messages.RecordUpdatedSuccessfully;
                            return RedirectToAction(Class.Actions.Index, Class.Controllers.Users);
                        }
                    }
                    else
                    {
                        if (model.UserId == 0)
                        {
                            ViewBag.Message = new object[] { SystemEnum.MessageType.error.ToString(), Messages.UserInsertFailed };
                        }
                        else if (model.UserId > 0)
                        {
                            ViewBag.Message = new object[] { SystemEnum.MessageType.error.ToString(), Messages.UserUpdateFailed };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                ViewBag.Message = new object[] { SystemEnum.MessageType.success.ToString(), Messages.GeneralMessage };
            }
            finally
            {
                ViewBag.UserTypeList = _dropdownManager.GetUserTypeList();
            }
            return View(model);
        }
        public ActionResult Delete(string uid)
        {
            try
            {
                bool result = userManager.DeleteUser(Convert.ToInt32(uid));
                if (result)
                {
                    return Json(new object[] { 1, SystemEnum.MessageType.success.ToString(), Messages.RecordDeletedSuccessfully });
                }
                else
                {
                    return Json(new object[] { 0, SystemEnum.MessageType.error.ToString(), Messages.GeneralMessage });
                }
            }
            catch (Exception)
            {
                return Json(new object[] { 0, SystemEnum.MessageType.error.ToString(), Messages.GeneralMessage });
            }
        }

    }
}