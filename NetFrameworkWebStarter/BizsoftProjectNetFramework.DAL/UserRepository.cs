using NetFrameworkWebStarter.DataProvider;
using NetFrameworkWebStarter.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace NetFrameworkWebStarter.DAL
{
    public class UserRepository
    {
        private SqlDataProvider Context;
        public UserRepository()
        {
            this.Context = new SqlDataProvider();
        }
        public UserModel LoginUser(string userName)
        {
            object[] parameters = {
                    new SqlParameter("UserName", SqlDbType.VarChar) {Value = userName.Trim() }
                };

            string userSearchQuery = $@"select top 1 * from Users USR 
                                                WHERE UPPER(TRIM(USR.UserName)) = UPPER(TRIM(@UserName))";

            UserModel model = Context.SelectQuery<UserModel>($@"{userSearchQuery}", parameters).FirstOrDefault();
            return model;

        }

        public List<UserModel> GetUserData(CommonSearchModel searchModel)
        {
            var model = new List<UserModel>();
            try
            {
                object[] parameters = {
                    new SqlParameter("SearchString", (object)searchModel.SearchString ?? DBNull.Value),
                    new SqlParameter("StartRowIndex", SqlDbType.Int) {Value = searchModel.StartRowIndex },
                    new SqlParameter("EndRowIndex", SqlDbType.Int) {Value = searchModel.EndRowIndex },
                    new SqlParameter("SortExpression", (object)searchModel.SortExpression ?? DBNull.Value),
                    new SqlParameter("SortDirection", (object)searchModel.SortDirection ?? DBNull.Value)
                };

                model = Context.SelectQuery<UserModel>($@"
                                    IF(@SortExpression is null) BEGIN SET @SortExpression = 'UserName' END
                                        ;WITH AllRecord AS
                                            (SELECT ROW_NUMBER() OVER (ORDER BY 
		                                        CASE WHEN @SortExpression = 'UserName' and @SortDirection ='desc'  THEN UserName END DESC, 
                                                CASE WHEN @SortExpression = 'UserName' THEN UserName END ASC
                                            ) As RowIndex,  
		                                        UserId,UserName,FullName,IsActive, UserTypeId
			                                        FROM Users
						                            WHERE (Upper([UserName]) Like '%'+ Upper(@SearchString) +'%' OR @SearchString IS NULL)
                                        ), 
                                        filteredRec AS ( SELECT COUNT(1) FilteredRecord  FROM AllRecord ),
                                        AllRecordCount AS ( SELECT COUNT(1) TotalRecords  FROM Users )
                                                    SELECT * FROM AllRecord, AllRecordCount, filteredRec
                                        WHERE RowIndex >= ISNULL(@StartRowIndex,0) and RowIndex<= ISNULL (@EndRowIndex,RowIndex)", parameters).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
        public UserModel GetUserByID(int userId)
        {
            var model = new UserModel();
            try
            {
                object[] parameters = {
                    new SqlParameter("UserId", SqlDbType.Int) {Value = userId }
                };

                string query = $@"SELECT * FROM Users USR WHERE UserId = @UserId ";

                model = Context.SelectQuery<UserModel>(query, parameters).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public bool AddEditUser(UserModel model)
        {
            try
            {
                object[] parameters = {
                    new SqlParameter("UserId", SqlDbType.Int) {Value = model.UserId },
                    new SqlParameter("UserName", SqlDbType.VarChar) {Value = model.UserName },
                    new SqlParameter("FullName", SqlDbType.VarChar) {Value = model.FullName},
                    new SqlParameter("UserTypeId", (object)model.UserTypeId ?? DBNull.Value),
                    new SqlParameter("Password", (object)model.Password ?? DBNull.Value),
                    new SqlParameter("IsActive", SqlDbType.Bit) {Value = model.IsActive}

                };
                int userId = 0;
                if (model.UserId > 0)
                {
                    userId = (int)Context.ExecuteScalar("UPDATE Users SET UserName = @UserName, FullName=@FullName, UserTypeId=@UserTypeId, IsActive=@IsActive, Password=@Password OUTPUT DELETED.UserId WHERE UserId = @UserId"
                                                                        , parameters);


                }
                else
                {
                    userId = (int)Context.ExecuteScalar($@"INSERT INTO Users (UserName, FullName, UserTypeId, Password, IsActive) 
                                                                        OUTPUT INSERTED.UserId 
                                                                        VALUES(@UserName, @FullName, @UserTypeId, @Password, @IsActive)", parameters);
                    model.UserId = userId;
                }
                return userId > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteUser(int userId)
        {
            bool result = false;
            try
            {
                object[] parameters = {
                    new SqlParameter("UserId", SqlDbType.Int) {Value = userId }
                };
                string query = $@"Delete Users WHERE UserId = @UserId";
                Context.ExecuteNonQuery(query, parameters);
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
