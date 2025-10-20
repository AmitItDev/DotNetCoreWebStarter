using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysproConnector.Models.JobModels
{
    public class SysproJobLabour
    {

        public string Job { get; set; }
        public string LabourActionType { get; set; }
        public string WorkCentre { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Iquantity { get; set; }
        public string IExpUnitRuntime { get; set; }
        public string IWcRateInd { get; set; }
        public string RunTimeIssued { get; set; }
        public string Operation { get; set; }
        public string UnitNumOfPieces { get; set; } = "1";
        public string IMaxWorkOpertrs { get; set; } = "1";
        public string IMaxProdUnits { get; set; } = "1";

    }
}
