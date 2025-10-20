using System;
using System.ComponentModel;
using System.Reflection;

namespace BizsoftProjectNetFramework.Infrastructure
{
    public class SystemEnum
    {
        public enum MessageType
        {
            /// <summary>
            /// for Success message Class
            /// </summary>
            success,

            /// <summary>
            /// for error message Class
            /// </summary>
            error,

            /// <summary>
            /// for Warning message Class
            /// </summary>
            warning,

            /// <summary>
            /// for Info message Class
            /// </summary>
            info
        }
        public enum UserType
        {
            [Description("Admin")]
            Admin = 1,
            [Description("User")]
            User = 2
        }
    }
    public class EnumManager
    {

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
