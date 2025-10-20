namespace SysproConnector.Models.InfrastructureModels
{
    public class SysproBinTransferModel
    {
        public string Warehouse { get; set; }
        public string StockCode { get; set; }
        public string SourceBin { get; set; }
        public string TargetBin { get; set; }
        public decimal Qty { get; set; }
        public string Description { get; set; }
    }
}
