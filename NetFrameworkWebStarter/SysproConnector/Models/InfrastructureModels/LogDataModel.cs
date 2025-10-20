using System;
using static SysproConnector.Infrastructure.SystemEnum;

namespace SysproConnector.Models
{
    public class LogDataModel
    {
        public int LogId { get; set; }
        public string SourceUser { get; set; }
        public string SysproOperator { get; set; }
        public string SysproCompany { get; set; }
        public string Action { get; set; }
        public DateTime DateLogged { get; set; } = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        public DateTime DateProcessed { get; set; } = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        public string BusinessObject { get; set; } = string.Empty;
        public string SysproInput { get; set; } = string.Empty;
        public string SysproOutput { get; set; } = string.Empty;
        public string SysproParameter { get; set; } = string.Empty;
        public string SysproKey { get; set; }
        public string SourceKey { get; set; }
        public string AdditionData { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public string Status { get; set; }
        public int ApplicationId { get;set; }

    }

    public class SysproAudit
    {
        public int LogId { get; set; }
        public string Operator { get; set; }
        public DateTime ActionOn { get; set; }
        public string Action { get; set; }
        public string BusinessObject { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public string InputSettings { get; set; }
        public string RequestConnectorData { get; set; }
        public string AssistedSearchParam { get; set; }
        public string Messages { get; set; }
        public bool Result { get; set; }
        public string TransactionReference { get; set; }
        public string WMSUser { get; set; } = string.Empty;
    }
}
