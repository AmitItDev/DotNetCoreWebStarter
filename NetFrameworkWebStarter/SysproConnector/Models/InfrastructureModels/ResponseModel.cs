using System.Collections.Generic;

namespace SysproConnector.Models
{
    public class ResponseModel
    {
        public bool RequestStatus { get; set; } = false;

        public List<string> ResponseMessages { get; set; } = new List<string>();

        public object ResponseData { get; set; } = string.Empty;
        public ResponseModel Clone() => (ResponseModel)this.MemberwiseClone();
        public Dictionary<string, string> allInvoices = new Dictionary<string, string>();
    }
    public class SysproItemResult
    {
        public string StockCode { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class DiamondClubResponse
    {
        public ResponseModel ResponseModel { get; set; } = new ResponseModel();
        public bool InvoiceType { get; set; } = true;
    }
}
