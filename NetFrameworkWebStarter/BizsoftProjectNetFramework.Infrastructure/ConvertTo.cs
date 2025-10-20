using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFrameworkWebStarter.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Reflection;
    using System.Web;
    using System.IO;

    /// <summary>
    ///  Manage to Convert the Data Type to other Data Type
    /// </summary>
    /// <CreatedBy>Template</CreatedBy>
    /// <CreatedDate>20-November-2018</CreatedDate>
    /// <ModifiedBy></ModifiedBy>
    /// <ModifiedDate></ModifiedDate>
    /// <ReviewBy></ReviewBy>
    /// <ReviewDate></ReviewDate>
    public sealed class ConvertTo
    {
        #region Constructor

        /// <summary>
        /// Prevents a default instance of the ConvertTo class from being created.
        /// </summary>
        private ConvertTo()
        {
        }

        #endregion

        #region Variable/Property Declaration
        #endregion

        #region Methods/Functions

        /// <summary> 
        /// check for given value is null string 
        /// </summary> 
        /// <param name="readField">object to convert</param> 
        /// <returns>if value=string return string else ""</returns> 
        public static string String(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    return Convert.ToString(readField, CultureInfo.InvariantCulture);
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary> 
        /// check for given value is not double 
        /// </summary> 
        /// <param name="readField">object to convert</param> 
        /// <returns>if value=double return double else 0.0</returns> 
        public static double Double(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    if (readField.ToString().Trim().Length == 0)
                    {
                        return 0.0;
                    }
                    else
                    {
                        return Convert.ToDouble(readField, CultureInfo.InvariantCulture);
                    }
                }
                else
                {
                    return 0.0;
                }
            }
            else
            {
                return 0.0;
            }
        }

        /// <summary> 
        /// check for given value is not decimal 
        /// </summary> 
        /// <param name="readField">object to convert</param> 
        /// <returns>if value=double return double else 0.0</returns> 
        public static decimal Decimal(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    if (readField.ToString().Trim().Length == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        decimal x;
                        if (decimal.TryParse(readField.ToString(), out x))
                        {
                            x = decimal.Round(x, ProjectConfiguration.DecimalPlace);
                            return x;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary> 
        /// check given value is boolean or null 
        /// </summary> 
        /// <param name="readField">object to convert</param> 
        /// <returns>return true else false</returns> 
        public static bool Boolean(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    bool x;
                    if (bool.TryParse(Convert.ToString(readField, CultureInfo.InvariantCulture), out x))
                    {
                        return x;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary> 
        /// check given value is boolean or null 
        /// </summary> 
        /// <param name="readField">object to convert</param> 
        /// <returns>return true else false</returns> 
        public static bool? BoolNull(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    bool x;
                    if (bool.TryParse(Convert.ToString(readField, CultureInfo.InvariantCulture), out x))
                    {
                        return x;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary> 
        /// check given value is integer or null 
        /// </summary> 
        /// <param name="readField">object to convert</param> 
        /// <returns>return integer else 0</returns> 
        public static int Integer(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    if (readField.ToString().Trim().Length == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        int toReturn;
                        if (int.TryParse(Convert.ToString(readField, CultureInfo.InvariantCulture), out toReturn))
                        {
                            return toReturn;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary> 
        /// check given value is long or null 
        /// </summary> 
        /// <param name="readField">object to convert</param> 
        /// <returns>return long else 0</returns> 
        public static long Long(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    if (readField.ToString().Trim().Length == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        long toReturn;
                        if (long.TryParse(Convert.ToString(readField, CultureInfo.InvariantCulture), out toReturn))
                        {
                            return toReturn;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary> 
        /// check given value is short or null 
        /// </summary> 
        /// <param name="readField">object to convert</param> 
        /// <returns>return short else 0</returns> 
        public static short Short(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    if (readField.ToString().Trim().Length == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        short toReturn = 0;
                        if (short.TryParse(Convert.ToString(readField, CultureInfo.InvariantCulture), out toReturn))
                        {
                            return toReturn;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary> 
        /// check given value of date is date or null 
        /// </summary> 
        /// <param name="readField">date value to check</param> 
        /// <returns>return date if valid format else return nothing</returns> 
        public static DateTime? Date(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    DateTime dateReturn;
                    if (DateTime.TryParse(Convert.ToString(readField, CultureInfo.CurrentCulture), out dateReturn))
                    {
                        //return Convert.ToDateTime(readField, CultureInfo.InvariantCulture);
                        return dateReturn;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return null;
        }

        /// <summary> 
        /// check given value of date is date or null 
        /// </summary> 
        /// <param name="readField">date value to check</param> 
        /// <returns>return date if valid format else return nothing</returns> 
        public static string DateFormat(object readField)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    DateTime dateReturn;
                    if (DateTime.TryParse(Convert.ToString(readField, CultureInfo.CurrentCulture), out dateReturn))
                    {
                        return Convert.ToDateTime(readField, CultureInfo.InvariantCulture).GetDateTimeFormats('d', CultureInfo.InvariantCulture)[5];
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }

            return string.Empty;
        }

        /// <summary> 
        /// check given value of date is date or null 
        /// </summary> 
        /// <param name="readField">date value to check</param> 
        /// <param name="dateFormat">Date format</param> 
        /// <returns>return date if valid format else return nothing</returns> 
        public static string Date(object readField, string dateFormat)
        {
            if (readField != null)
            {
                if (readField.GetType() != typeof(System.DBNull))
                {
                    if (!string.IsNullOrEmpty(dateFormat))
                    {
                        return Convert.ToDateTime(readField, CultureInfo.CurrentCulture).ToString(dateFormat, CultureInfo.InvariantCulture);
                    }

                    return Convert.ToDateTime(readField, CultureInfo.CurrentCulture).ToString(CultureInfo.CurrentCulture);
                }
            }

            return DateTime.MinValue.ToString(CultureInfo.CurrentCulture);
        }

        /// <summary> 
        /// for save null value in database 
        /// </summary> 
        /// <param name="value">object to convert</param> 
        /// <returns>return DBNull value</returns> 
        public static object DBNullValue(string value)
        {
            if (value == null | string.IsNullOrEmpty(value))
            {
                return System.DBNull.Value;
            }

            return value;
        }

        /// <summary>
        /// To check null value
        /// </summary>
        /// <param name="value">object to check</param>
        /// <returns>if null than returns DBNull.Value else returns object which is passed</returns>
        public static object ToDBNull(object value)
        {
            if (null != value)
            {
                return value;
            }

            return DBNull.Value;
        }

        public static byte[] Bytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        public static DataTable DataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Get all the properties
            List<PropertyInfo> props = new List<PropertyInfo>(typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance));
            props.ForEach(prop => dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType));
            items.ForEach(item =>
            {
                DataRow dr = dataTable.NewRow();
                props.ForEach(prop => dr[prop.Name] = prop.GetValue(item, null) ?? DBNull.Value);
                dataTable.Rows.Add(dr);
            });
            // put a breakpoint here and check datatable
            return dataTable;
        }


        public static byte[] ByteArrayFromFile(string sFilePathAndName)
        {
            byte[] buffer = null;
            if (System.IO.File.Exists(sFilePathAndName) == true)
            {
                using (FileStream fs = new FileStream(sFilePathAndName, FileMode.Open, FileAccess.Read))
                {
                    buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, (int)fs.Length);
                }
            }
            return buffer;
        }

        /// <summary>
        /// Converts datatable to list<T> dynamically
        /// </summary>
        /// <typeparam name="T">Class name</typeparam>
        /// <param name="dataTable">data table to convert</param>
        /// <returns>List<T></returns>
        public static List<T> ToList<T>(DataTable dataTable) where T : new()
        {
            var dataList = new List<T>();

            //Define what attributes to be read from the class
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;

            //Read Attribute Names and Types
            var objFieldNames = typeof(T).GetProperties(flags).Cast<PropertyInfo>().
                Select(item => new
                {
                    Name = item.Name,
                    Type = Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType
                }).ToList();

            //Read Datatable column names and types
            var dtlFieldNames = dataTable.Columns.Cast<DataColumn>().
                Select(item => new
                {
                    Name = item.ColumnName,
                    Type = item.DataType
                }).ToList();

            foreach (DataRow dataRow in dataTable.AsEnumerable().ToList())
            {
                var classObj = new T();

                foreach (var dtField in dtlFieldNames)
                {
                    PropertyInfo propertyInfos = classObj.GetType().GetProperty(dtField.Name);

                    var field = objFieldNames.Find(x => x.Name == dtField.Name);

                    if (field != null)
                    {

                        if (propertyInfos.PropertyType == typeof(DateTime))
                        {
                            propertyInfos.SetValue
                            (classObj, ConvertTo.Date(dataRow[dtField.Name]), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(int))
                        {
                            propertyInfos.SetValue
                            (classObj, ConvertTo.Integer(dataRow[dtField.Name]), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(long))
                        {
                            propertyInfos.SetValue
                            (classObj, ConvertTo.Double(dataRow[dtField.Name]), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(decimal))
                        {
                            propertyInfos.SetValue
                            (classObj, ConvertTo.Decimal(dataRow[dtField.Name]), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(bool))
                        {
                            propertyInfos.SetValue
                            (classObj, ConvertTo.BoolNull(dataRow[dtField.Name]), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(String))
                        {
                            if (dataRow[dtField.Name].GetType() == typeof(DateTime))
                            {
                                propertyInfos.SetValue
                                (classObj, ConvertTo.Date(dataRow[dtField.Name]), null);
                            }
                            else
                            {
                                propertyInfos.SetValue
                                (classObj, ConvertTo.String(dataRow[dtField.Name]), null);
                            }
                        }
                    }
                }
                dataList.Add(classObj);
            }
            return dataList;
        }

        /// <summary>
        /// This function converts plain text to base64 string
        /// </summary>
        /// <param name="plainText">String that has to be converted to base64 string</param>
        /// <returns>base64 string</returns>
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// This function converts base64 string to plain text
        /// </summary>
        /// <param name="base64EncodedData">Base64 Encoded Data</param>
        /// <returns>plain text string</returns>
        public static string Base64Decode(string base64EncodedData)
        {
            try
            {
                if (!string.IsNullOrEmpty(base64EncodedData))
                {
                    var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData.Replace(" ", "+"));
                    return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string FormatMoney(decimal amount, string decimalPoint = ".", string thousands = ",",
            string currancySymbol = "R", string decimalCount = "2")
        {
            var nfi = new NumberFormatInfo
            {
                NumberGroupSeparator = thousands, // set the group separator to a space
                NumberDecimalSeparator = decimalPoint
            };
            return currancySymbol + ' ' + amount.ToString("N" + decimalCount, nfi); // numeric format with 2 decimal digits
        }
        #endregion
    }
}
