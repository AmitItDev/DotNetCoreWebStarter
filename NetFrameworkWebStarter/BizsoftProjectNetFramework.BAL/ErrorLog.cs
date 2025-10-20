using BizsoftProjectNetFramework.DAL;
using BizsoftProjectNetFramework.Infrastructure;
using BizsoftProjectNetFramework.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BizsoftProjectNetFramework.BAL
{
    public class ErrorLog
    {
        #region Properties

        /// <summary>
        /// The _error log repository
        /// </summary>
        private static ErrorLogRepository _errorLogRepository;

        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorLog"/> class.
        /// </summary>
        public ErrorLog()
        {
            _errorLogRepository = new ErrorLogRepository();
        }

        #endregion

        #region Methods

        public static int Log(Exception ex)
        {
            try
            {
                if (ConfigurationManager.AppSettings["ErrorLog"] == "true")
                {
                    List<string> lstExMsg = new List<string>();
                    List<string> lstExStackTrace = new List<string>();

                    if (!string.IsNullOrEmpty(ex.Message))
                        lstExMsg.Add(ex.Message);

                    if (!string.IsNullOrEmpty(ex.StackTrace))
                        lstExStackTrace.Add(ex.StackTrace);

                    while (ex.InnerException != null)
                    {
                        if (!string.IsNullOrEmpty(ex.InnerException.Message))
                            lstExMsg.Add(ex.InnerException.Message);

                        if (!string.IsNullOrEmpty(ex.InnerException.StackTrace))
                            lstExStackTrace.Add(ex.InnerException.StackTrace);

                        ex = ex.InnerException;
                    }

                    string errorMessage = null;
                    if (lstExMsg.Any())
                        errorMessage = string.Join(",", lstExMsg);

                    string stackTrace = null;
                    if (lstExStackTrace.Any())
                        stackTrace = string.Join(",", lstExStackTrace);

                    return Log(errorMessage, stackTrace, ex.Source, ex.TargetSite != null ? ex.TargetSite.Name : string.Empty);
                }
                else
                    return 1;
            }
            catch
            { }
            return 0;
        }

        /// <summary>
        /// Logs the specified error message.
        /// </summary>
        /// <param name="ErrorMessage">The error message.</param>
        /// <param name="ErrorStackTrace">The error stack trace.</param>
        /// <param name="ErrorSource">The error source.</param>
        /// <param name="ErrorTargetSite">The error target site.</param>
        /// <returns></returns>
        public static int Log(string ErrorMessage, string ErrorStackTrace, string ErrorSource, string ErrorTargetSite)
        {
            ErrorLogModel objErrorLog = new ErrorLogModel();

            objErrorLog.ErrorDate = DateTime.Now;
            try
            {

                objErrorLog.LoginID = ProjectSession.UserID != null ? ProjectSession.UserID : 0;
            }
            catch (Exception ex)
            {

                objErrorLog.LoginID = 0;
            }

            try
            {

                if ((HttpContext.Current.Request.UrlReferrer == null) == false)
                {
                    objErrorLog.UrlReferrer = HttpContext.Current.Request.UrlReferrer.PathAndQuery;
                }
                objErrorLog.IPAddress = HttpContext.Current.Request.UserHostAddress;
                objErrorLog.ClientBrowser = HttpContext.Current.Request.Browser.Browser + " " + HttpContext.Current.Request.Browser.Version;

                objErrorLog.URL = HttpContext.Current.Request.Url.PathAndQuery;

                objErrorLog.QueryString = HttpContext.Current.Request.QueryString.ToString();
                objErrorLog.PostData = HttpContext.Current.Request.Form.ToString();
            }
            catch
            {
                objErrorLog.IPAddress = "";
                objErrorLog.ClientBrowser = "";
                objErrorLog.URL = "";
                objErrorLog.QueryString = "";
                objErrorLog.PostData = "";
                objErrorLog.UrlReferrer = "";
            }

            objErrorLog.ErrorMessage = ErrorMessage;
            objErrorLog.ErrorStackTrace = ErrorStackTrace;
            objErrorLog.ErrorSource = ErrorSource;
            objErrorLog.ErrorTargetSite = ErrorTargetSite;

            System.Text.StringBuilder SessionInfo = new System.Text.StringBuilder();
            try
            {
                System.Collections.Specialized.NameObjectCollectionBase.KeysCollection objSessionKeys = HttpContext.Current.Session.Keys;
                int i = 0;
                while ((i <= (objSessionKeys.Count - 1)))
                {
                    if ((HttpContext.Current.Session[i] == null) == false)
                    {
                        SessionInfo.Append((System.Environment.NewLine + ((i + 1).ToString() + (":->Name: " + objSessionKeys[i].ToString()))));
                        if ((HttpContext.Current.Session[i].GetType().Name == "String") || (HttpContext.Current.Session[i].GetType().Name.Contains("Int")))
                        {
                            SessionInfo.Append((" <-->  Value:" + HttpContext.Current.Session[ConvertTo.String(objSessionKeys[i])]));
                        }
                        if ((HttpContext.Current.Session[i].GetType().Name == "DataTable"))
                        {
                            SessionInfo.Append((" <-->  Value: Number of rows:" + ((System.Data.DataTable)HttpContext.Current.Session[ConvertTo.String(objSessionKeys[i])]).Rows.Count.ToString()));
                        }
                    }
                    i = (i + 1);
                }
            }
            catch (Exception ex)
            {

            }

            objErrorLog.SessionInfo = SessionInfo.ToString();
            _errorLogRepository = new ErrorLogRepository();
            return _errorLogRepository.AddErrorLog(objErrorLog);
        }

        #endregion
    }
}
