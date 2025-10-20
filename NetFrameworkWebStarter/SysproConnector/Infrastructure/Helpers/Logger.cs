using SysproConnector.DataProvider;
using SysproConnector.Models;
using SysproConnector.Repositories;

namespace SysproConnector.Infrastructure.Helpers
{
    internal static class Logger
    {
        internal static void LogSysproActivity(LogDataModel logData)
        {
            var SysproActivityLoggerRepository = new SysproActivityLoggerRepository(new SqlDataProvider());
            SysproActivityLoggerRepository.SaveSysproActivityLog(logData.SourceUser, logData.SysproOperator, logData.SysproCompany, logData.Action, logData.BusinessObject,
                logData.SysproInput, logData.SysproOutput, logData.SysproParameter, logData.SysproKey, logData.SourceKey, logData.AdditionData, logData.ErrorMessage,logData.Status, logData.ApplicationId);
        }

        internal static void UpdateSysproActivity(LogDataModel logData)
        {
            var SysproActivityLoggerRepository = new SysproActivityLoggerRepository(new SqlDataProvider());

            SysproActivityLoggerRepository.UpdateSysproActivityLog(logData.LogId, logData.SourceUser, logData.SysproOperator, logData.SysproCompany, logData.Action, logData.BusinessObject,
                logData.SysproInput, logData.SysproOutput, logData.SysproParameter, logData.SysproKey, logData.SourceKey, logData.AdditionData, logData.ErrorMessage, logData.Status);
        }
    }
}
