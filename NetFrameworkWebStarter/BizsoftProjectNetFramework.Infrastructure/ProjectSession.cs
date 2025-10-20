using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BizsoftProjectNetFramework.Infrastructure
{
    public class ProjectSession
    {
        /// <summary>
        /// Gets or sets Properties to store project session for Page Size
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public static int PageSize
        {
            get
            {
                if (HttpContext.Current.Session["PageSize"] == null)
                {
                    return 10;
                }
                else
                {
                    if (Convert.ToInt32(HttpContext.Current.Session["PageSize"]) == -1)
                    {
                        return 10;
                    }
                    return ConvertTo.Integer(HttpContext.Current.Session["PageSize"]);
                }
            }
            set
            {
                HttpContext.Current.Session["PageSize"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public static string UserName
        {
            get
            {
                if (HttpContext.Current.Session["UserName"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["UserName"].ToString();
                }
            }
            set { HttpContext.Current.Session["UserName"] = value; }
        }

        public static string FullName
        {
            get
            {
                if (HttpContext.Current.Session["FullName"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["FullName"].ToString();
                }
            }
            set { HttpContext.Current.Session["FullName"] = value; }
        }
        public static dynamic Settings
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session["Settings"] == null)
                {
                    return null;
                }
                else
                {
                    return HttpContext.Current.Session["Settings"];
                }
            }
            set { HttpContext.Current.Session["Settings"] = value; }
        }

        public static string Password
        {
            get
            {
                if (HttpContext.Current.Session["Password"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["Password"].ToString();
                }
            }
            set { HttpContext.Current.Session["Password"] = value; }
        }

        /// <summary>
        /// Gets or sets the login identifier.
        /// </summary>
        /// <value>
        /// The login identifier.
        /// </value>
        public static int UserID
        {
            get
            {
                if (HttpContext.Current.Session["UserID"] == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                }
            }
            set
            {
                HttpContext.Current.Session["UserID"] = value;
            }
        }
        public static int UserTypeId
        {
            get
            {
                if (HttpContext.Current.Session["UserTypeId"] == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(HttpContext.Current.Session["UserTypeId"]);
                }
            }
            set
            {
                HttpContext.Current.Session["UserTypeId"] = value;
            }
        }

    }
}
