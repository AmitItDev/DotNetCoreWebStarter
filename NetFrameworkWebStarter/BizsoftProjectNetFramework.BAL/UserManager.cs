using NetFrameworkWebStarter.DAL;
using NetFrameworkWebStarter.Infrastructure;
using NetFrameworkWebStarter.Models;
using DataTables.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NetFrameworkWebStarter.BAL
{
    public class UserManager
    {
        UserRepository userRepository;
        public UserManager()
        {
            userRepository = new UserRepository();
        }
        public UserModel LoginUser(string userName)
        {
            var model = new UserModel();
            try
            {
                model = userRepository.LoginUser(userName);
                return model;
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
            }
            return model;
        }
        public DataTablesResponse GetUserData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string searchString = null, string searchRole = null)
        {
            try
            {
                var searchModel = new CommonSearchModel();
                if (requestModel.Length > 0)
                {
                    searchModel.SortExpression = requestModel.Columns.FirstOrDefault(x => x.IsOrdered) != null ? requestModel.Columns.FirstOrDefault(x => x.IsOrdered).Data : "FullName";
                    searchModel.SortDirection = requestModel.OrderDir;
                }
                ProjectSession.PageSize = requestModel.Length;

                searchModel.SearchString = searchString;
                searchModel.StartRowIndex = requestModel.Start + 1;
                searchModel.EndRowIndex = requestModel.Start + ProjectSession.PageSize;
                var data = userRepository.GetUserData(searchModel);
                int totalRecord = 0, filteredRecord = 0;
                if (data != null && data.Count > 0)
                {
                    totalRecord = data[0].TotalRecords;
                    filteredRecord = data[0].FilteredRecord;
                }

                return new DataTablesResponse(requestModel.Draw, data, filteredRecord, totalRecord);
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
            }
            return new DataTablesResponse(requestModel.Draw, new List<UserModel>(), 0, 0);
        }

        public UserModel GetUserByID(int userId)
        {
            var model = new UserModel();
            try
            {
                model = userRepository.GetUserByID(userId);

                if (!string.IsNullOrEmpty(model.Password))
                {
                    model.Password = EncryptionDecryption.GetDecrypt(model.Password);
                }

                return model;
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
            }
            return model;
        }

        public bool AddEditUser(UserModel model)
        {
            bool status = false;
            try
            {
                if (!string.IsNullOrEmpty(model.Password))
                {
                    model.Password = EncryptionDecryption.GetEncrypt(model.Password);
                }

                status = userRepository.AddEditUser(model);
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
            }
            return status;
        }
        public bool DeleteUser(int userId)
        {
            bool result = false;
            try
            {
                result = userRepository.DeleteUser(userId);
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
            }
            return result;
        }

    }
}
