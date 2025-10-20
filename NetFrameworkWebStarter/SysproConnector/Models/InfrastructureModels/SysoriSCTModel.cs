using System.Collections.Generic;

namespace SysproConnector.Models.InfrastructureModels
{
   public class SysproSCTModel
    {
        public int SCTId { get; set; }
        public string SourceWarehouse { get; set; }
        public string TargetWarehouse { get; set; }
        public string Reference { get; set; }
        public List<SysproLines> Lines { get; set; }
    }
    public class SysproLines
    {
        public int LineId { get; set; }
        public int SCTId { get; set; }
        public string StockCode { get; set; }
        public string Description { get; set; }
        public string SourceBin { get; set; }
        public decimal Qty { get; set; }
        public decimal QtyAvailable { get; set; }
        public string StockUom { get; set; }
    }
}
