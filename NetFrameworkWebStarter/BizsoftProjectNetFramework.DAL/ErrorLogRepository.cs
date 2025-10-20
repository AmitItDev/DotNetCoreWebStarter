using NetFrameworkWebStarter.DataProvider;
using NetFrameworkWebStarter.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFrameworkWebStarter.DAL
{
    public class ErrorLogRepository : IDisposable
    {
        #region Properties

        private SqlDataProvider Context;

        #endregion

        #region Ctor

        public ErrorLogRepository()
        {
            this.Context = new SqlDataProvider();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the error log.
        /// </summary>
        /// <param name="objErrorLog">The object error log.</param>
        /// <returns></returns>
        public int AddErrorLog(ErrorLogModel objErrorLog)
        {
            try
            {
                object[] parameters = {
                    new SqlParameter("ErrorDate", (object)objErrorLog.ErrorDate ?? DBNull.Value),
                    new SqlParameter("LoginID", (object)objErrorLog.LoginID?? DBNull.Value),
                    new SqlParameter("IPAddress", (object)objErrorLog.IPAddress ?? DBNull.Value),
                    new SqlParameter("ClientBrowser", (object)objErrorLog.ClientBrowser ?? DBNull.Value),
                    new SqlParameter("ErrorMessage", (object)objErrorLog.ErrorMessage?? DBNull.Value),
                    new SqlParameter("ErrorStackTrace", (object)objErrorLog.ErrorStackTrace?? DBNull.Value),
                    new SqlParameter("URL", (object)objErrorLog.URL ?? DBNull.Value),
                    new SqlParameter("URLReferrer", (object)objErrorLog.UrlReferrer ?? DBNull.Value),
                    new SqlParameter("ErrorSource", (object)objErrorLog.ErrorSource ?? DBNull.Value),
                    new SqlParameter("ErrorTargetSite", (object)objErrorLog.ErrorTargetSite ?? DBNull.Value),
                    new SqlParameter("QueryString", (object)objErrorLog.QueryString ?? DBNull.Value),
                    new SqlParameter("PostData", (object)objErrorLog.PostData?? DBNull.Value),
                    new SqlParameter("SessionInfo", (object)objErrorLog.SessionInfo ?? DBNull.Value)
                };

                Context.ExecuteNonQuery($@"INSERT INTO ErrorLog (ErrorDate, LoginID, IPAddress, ClientBrowser, ErrorMessage, ErrorStackTrace, URL, URLReferrer, ErrorSource, ErrorTargetSite, QueryString, PostData, SessionInfo)
                    values ( @ErrorDate, @LoginID, @IPAddress, @ClientBrowser, @ErrorMessage, @ErrorStackTrace, @URL, @URLReferrer, @ErrorSource, @ErrorTargetSite, @QueryString, @PostData, @SessionInfo )", parameters);
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// The dispose method that implements IDisposable.
        /// </summary>
        public void Dispose()
        {
            this.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
