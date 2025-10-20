using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SysproConnector.DataProvider
{
    public class SqlClient
    {
        public static bool TestDatabaseConnection(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("Select 0", connection) { CommandTimeout = 60000 };
                    command.Connection.Open();
                }
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public static void ExecuteNonQuery(string queryString, string connectionString)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var command   = new SqlCommand(queryString, connection) { CommandTimeout = 60000 };
                    command.Connection.Open();
                    string result = $"Query result: {command.ExecuteNonQuery().ToString()}";
                }
            }
            catch (Exception exception)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($"Query String: {queryString}");
                stringBuilder.AppendLine(exception.Message);
                if (exception.InnerException != null)
                {
                    stringBuilder.AppendLine(exception.InnerException.Message);
                    if (exception.InnerException.InnerException != null)
                    {
                        stringBuilder.AppendLine(exception.InnerException.InnerException.Message);
                        if (exception.InnerException.InnerException.InnerException != null)
                        {
                            stringBuilder.AppendLine(exception.InnerException.InnerException.InnerException.Message);
                        }
                    }
                }

                throw new Exception(stringBuilder.ToString());
            }
        }

        public static DataTable SelectQuery(string queryString, string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(
                           connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.CommandTimeout = 600000;

                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command))
                    {
                        sqlDataAdapter.Fill(dataTable);
                    }

                    return dataTable;
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Unable to retrieve data, with error: {exception.Message} using connection: {connectionString}");
            }
        }

        public static string BuildContext(string server, string database, string user, string password) =>
            $"data source={server};initial catalog={database};user id={user};password={password};persist security info=True";


        public static IList<T> SelectQuery<T>(string queryString, string connectionString, object[] parameters)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(
                           connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);

                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    command.Connection.Open();
                    command.CommandTimeout = 600000;

                    return DataReaderToList<T>(command.ExecuteReader());
                    //DataTable dataTable = new DataTable();
                    //using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command))
                    //{
                    //    sqlDataAdapter.Fill(dataTable);
                    //}

                    //return dataTable;
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Unable to retrieve data, with error: {exception.Message} using connection: {connectionString}");
            }
        }

        internal static List<T> DataReaderToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();

            T obj = default(T);

            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();

                for (int i = 0; i < dr.FieldCount; i++)
                {
                    PropertyInfo info = obj.GetType().GetProperties().FirstOrDefault(o => o.Name.ToLower() == dr.GetName(i).ToLower());
                    if (info != null)
                    {
                        if (info.PropertyType.Name == "String")
                        {
                            /*Set the Value to Model*/
                            info.SetValue(obj, dr.GetValue(i) != System.DBNull.Value ? (dr.GetValue(i)).ToString().TrimEnd() : null, null);
                        }
                        else
                        {
                            /*Set the Value to Model*/
                            info.SetValue(obj, dr.GetValue(i) != System.DBNull.Value ? dr.GetValue(i) : null, null);
                        }
                    }
                }
                list.Add(obj);
            }
            return list;
        }
    }
}
