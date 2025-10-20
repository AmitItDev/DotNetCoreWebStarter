using System.Data;
using System.Configuration;
using System.Collections.Generic;

namespace SysproConnector.DataProvider
{
    public class SqlDataProvider
    {
        public string GetContext() => ConfigurationManager.ConnectionStrings["L2LConnectionString"].ToString();

        public DataTable SelectQuery(string queryString) => SqlClient.SelectQuery(queryString, GetContext());

        public void ExecuteNonQuery(string queryString) => SqlClient.ExecuteNonQuery(queryString, GetContext());

        public bool TestApplicationDatabaseConnection() => SqlClient.TestDatabaseConnection(GetContext());



        public string GetSysproContext() => ConfigurationManager.ConnectionStrings["L2LSysproConnectionString"].ToString();

        public DataTable SysproSelectQuery(string queryString) => SqlClient.SelectQuery(queryString, GetSysproContext());

        public void SysproExecuteNonQuery(string queryString)  => SqlClient.ExecuteNonQuery(queryString, GetSysproContext());

        public bool SysproTestApplicationDatabaseConnection()  => SqlClient.TestDatabaseConnection(GetSysproContext());
        public IList<T> SysproSelectQuery<T>(string queryString, object[] parameters = null) => SqlClient.SelectQuery<T>(queryString, GetSysproContext(), parameters);

    }
}
