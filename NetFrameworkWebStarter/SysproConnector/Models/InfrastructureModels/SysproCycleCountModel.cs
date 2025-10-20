namespace SysproConnector.Models.InfrastructureModels
{
    public class SysproCycleCountModel
    {
        public string Warehouse { get; set; }

        public string StockCode { get; set; }

        public string Version { get; set; }

        public string Release { get; set; }

        public decimal Quantity { get; set; }

        public string UnitOfMeasure { get; set; }

        public string BinLocation { get; set; }

        public string Reference { get; set; }
        
        public string LedgerCode { get; set; }

    }
}
