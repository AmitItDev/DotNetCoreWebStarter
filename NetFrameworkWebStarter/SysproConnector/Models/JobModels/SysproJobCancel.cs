using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysproConnector.Models.JobModels
{
    public class SysproJobCancel
    {
        public string Job { get; set; }
        public string CancelReasonCode { get; set; }
        public string SalesOrder { get; set; }
        
    }
}
