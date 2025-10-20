using BizsoftProjectNetFramework.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BizsoftProjectNetFramework.Models
{
    public class LoginInputModel
    {
        /// <summary>
        /// username for login from mobile app
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// password for login from mobile app.
        /// </summary>
        public string Password { get; set; }
    }
    public class UserModel : BaseModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int? UserTypeId { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public string UserType
        {
            get
            {
                if (UserTypeId == null)
                    return string.Empty;

                var type = typeof(SystemEnum.UserType);
                var member = type.GetMember(((SystemEnum.UserType)UserTypeId).ToString()).FirstOrDefault();

                if (member != null)
                {
                    var attr = member.GetCustomAttribute<DescriptionAttribute>();
                    if (attr != null)
                        return attr.Description;
                }

                return ((SystemEnum.UserType)UserTypeId).ToString();
            }
        }
    }
}
