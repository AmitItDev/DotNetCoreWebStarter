using SysproConnector.DataProvider;
using System;
using System.Configuration;

namespace SysproConnector.Repositories
{
    internal class SysproActivityLoggerRepository
    {
        private SqlDataProvider DataProvider;

        internal SysproActivityLoggerRepository(SqlDataProvider dataProvider)
        {
            this.DataProvider = dataProvider;
        }

        internal bool SaveSysproActivityLog(string SourceUser, string SysproOperator, string SysproCompany, string action, string businessObject, string SysproInput, string SysproOutput,
            string SysproParameter, string SysproKey, string SourceKey, string AdditionData, string ErrorMessage, string Status, int applicationId)
        {
            var result = false;

            string sql = $@"INSERT INTO [SysproActivityLog] ([SourceUser]
                                                               ,[SysproOperator]
                                                               ,[SysproCompany]
                                                               ,[Action]
                                                               ,[DateLogged]
                                                               ,[DateProcessed]
                                                               ,[BusinessObject]
                                                               ,[SysproInput]
                                                               ,[SysproOutput]
                                                               ,[SysproParameter]
                                                               ,[SysproKey]
                                                               ,[SourceKey]
                                                               ,[AdditionData]
                                                               ,[ErrorMessage]
                                                               ,[Status]
                                                               ,[ApplicationId]) 
                                                       VALUES ('{SourceUser}',
                                                               '{SysproOperator}',
                                                               '{SysproCompany}',
                                                               '{action}',
                                                               GETDATE(),
                                                               NULL,
                                                               '{businessObject}',
                                                               '{SysproInput.Replace("'", "")}',
                                                               '{SysproOutput.Replace("'", "")}',
                                                               '{SysproParameter.Replace("'", "")}',
                                                               '{SysproKey}',
                                                               '{SourceKey}',
                                                               '{AdditionData}',
                                                               '{ErrorMessage.Replace("'", "")}',
                                                               '{Status}'
                                                               ,{applicationId})";
            try
            {
                DataProvider.SelectQuery(sql);
                result = true;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message + Environment.NewLine + sql);
            }
            return result;
        }

        internal bool UpdateSysproActivityLog(int LogId, string SourceUser, string SysproOperator, string SysproCompany, string action, string businessObject, string SysproInput, string SysproOutput,
            string SysproParameter, string SysproKey, string SourceKey, string AdditionData, string ErrorMessage, string Status)
        {
            var result = false;
            string sql = $@" UPDATE [SysproActivityLog] SET 
                                                    [SourceUser] = '{SourceUser}',
                                                    [SysproOperator] = '{SysproOperator}',
                                                    [SysproCompany] = '{SysproCompany}',
                                                    [Action] = '{action}',
                                                    [DateLogged] = GETDATE(),
                                                    [DateProcessed] = NULL,
                                                    [BusinessObject] = '{businessObject}',
                                                    [SysproInput] = '{SysproInput}',
                                                    [SysproOutput] = '{SysproOutput}',
                                                    [SysproParameter] = '{SysproParameter}',
                                                    [SysproKey] = '{SysproKey}',
                                                    [SourceKey] = '{SourceKey}',
                                                    [AdditionData] = '{AdditionData}',
                                                    [ErrorMessage] = '{ErrorMessage}',
                                                    [Status] = '{Status}'
                                            WHERE LogId = {LogId}";
            try
            {
                DataProvider.SelectQuery(sql);
                result = true;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message + Environment.NewLine + sql);
            }
            return result;
        }
        internal bool UpdateCreditNoteStatus(string creditNoteNo)
        {
            var result = false;
            string dbName = ConfigurationManager.AppSettings["SysproDDBName"].ToString();

            string sql = $@"UPDATE {dbName}.dbo.SorMaster SET OrderStatus = '8' WHERE SalesOrder = '{creditNoteNo}' AND OrderStatus = 'S'";

            try
            {
                DataProvider.ExecuteNonQuery(sql);
                result = true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
