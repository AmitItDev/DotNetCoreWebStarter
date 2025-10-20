using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NetFrameworkWebStarter.Infrastructure
{
    public class ProjectConfiguration
    {

        /// <summary>
        /// Gets the Decimal Place
        /// </summary>
        public static int DecimalPlace
        {
            get
            {
                return 2;
            }
        }

        #region Site UrlPath

        /// <summary>
        /// Gets Url Suffix
        /// </summary>
        private static string UrlSuffix
        {
            get
            {
                var req = HttpContext.Current.Request;
                var host = req.Url.Host;
                if (req.IsLocal == true && req.Url.Port != 80)
                    host += ":" + req.Url.Port;

                if (HttpContext.Current.Request.ApplicationPath == "/")
                {
                    return host + HttpContext.Current.Request.ApplicationPath;
                }
                else
                {
                    return host + HttpContext.Current.Request.ApplicationPath + "/";
                }
            }
        }


        /// <summary>
        /// Gets the Root Path of the Project
        /// </summary>
        public static string ApplicationRootPath
        {
            get
            {
                string rootPath = HttpContext.Current.Server.MapPath("~");
                if (rootPath.EndsWith("\\", StringComparison.CurrentCulture))
                {
                    return rootPath;
                }
                else
                {
                    return rootPath + "\\";
                }
            }
        }

        /// <summary>
        /// Gets HostName
        /// </summary>
        public static string HostName
        {
            get { return HttpContext.Current.Request.Url.Host; }
        }

        /// <summary>
        /// Gets Secure User Base
        /// </summary>
        public static string SecureUrlBase
        {
            get
            {
                return "https://" + UrlSuffix;
            }
        }

        /// <summary>
        /// Gets Url Base
        /// </summary>
        public static string UrlBase
        {
            get
            {
                return "http://" + UrlSuffix;
            }
        }

        /// <summary>
        /// Gets Site Url Base
        /// </summary>
        public static string SiteUrlBase
        {
            get
            {
                if (HttpContext.Current.Request.IsSecureConnection)
                {
                    return SecureUrlBase;
                }
                else
                {
                    return UrlBase;
                }
            }
        }
        /// <summary>
        /// Gets Upload path
        /// </summary>
        public static string UploadPath
        {
            get
            {
                return ConfigurationManager.AppSettings["UploadPath"].ToString(); ;
            }
        }

        /// <summary>
        /// Gets Email Template Path
        /// </summary>
        public static string EmailTemplatePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/EmailTemplates/");
            }
        }
        #endregion Site UrlPath
    }
    public class EmailApiMethods
    {
        public static readonly string Create = "create";
        public static readonly string GetSentEmails = "getsentemails";
    }
}
