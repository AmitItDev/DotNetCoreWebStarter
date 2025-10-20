using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizsoftProjectNetFramework.DataProvider
{
    public class SqlDataProvider
    {
        #region DB
        public string GetContext() => ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();

        public IList<T> SelectQuery<T>(string queryString, object[] parameters = null) => SqlClient.SelectQuery<T>(queryString, GetContext(), parameters);

        public void ExecuteNonQuery(string queryString, object[] parameters = null) => SqlClient.ExecuteNonQuery(queryString, GetContext(), parameters);

        public object ExecuteScalar(string queryString, object[] parameters = null) => SqlClient.ExecuteScalar(queryString, GetContext(), parameters);

        public bool TestApplicationDatabaseConnection() => SqlClient.TestDatabaseConnection(GetContext());

        #endregion


        #region SysproCompanyDB
        public string GetSysproContext() => ConfigurationManager.ConnectionStrings["SysproConnectionString"].ConnectionString.ToString();

        public IList<T> SysproSelectQuery<T>(string queryString, object[] parameters = null) => SqlClient.SelectQuery<T>(queryString, GetSysproContext(), parameters);

        public void SysproExecuteNonQuery(string queryString, object[] parameters = null) => SqlClient.ExecuteNonQuery(queryString, GetSysproContext(), parameters);

        public bool SysproTestApplicationDatabaseConnection() => SqlClient.TestDatabaseConnection(GetSysproContext());

        public object SysproExecuteScalar(string queryString, object[] parameters = null) => SqlClient.ExecuteScalar(queryString, GetSysproContext(), parameters);
        public object SysproExecuteScalarGeneric(string queryString, object[] parameters = null) => SqlClient.ExecuteScalarGeneric(queryString, GetSysproContext(), parameters);

        #endregion
    }
}
