using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysproConnector.Models.JobModels
{
    public class SysproJobCollection
    {
        public SysproJobModel sysproJobModel { get; set; } = new SysproJobModel();
        public JobCustomFields jobCustomFields { get; set; } = new JobCustomFields();
    }

    public class SysproJobModel
    {
        public string ActionType { get; set; }
        public string JobNumber { get; set; }
        public string JobDescription { get; set; }
        public string StockCode { get; set; }
        public string StockDescription { get; set; }
        public string Warehouse { get; set; }
        public string JobClassification { get; set; }
        public string QtyToMake { get; set; }
        public string Customer { get; set; }
        public string CustomerName { get; set; }
        public string JobTenderDate { get; set; }
        public string ConfirmedFlag { get; set; }
        public string NonStocked { get; set; } = "Y";
    }
}
