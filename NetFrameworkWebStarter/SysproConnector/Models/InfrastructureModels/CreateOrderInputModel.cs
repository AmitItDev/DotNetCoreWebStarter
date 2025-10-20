using System.Collections.Generic;

namespace SysproConnector.Models.InfrastructureModels
{
    public class Orders
    {
        public Orders()
        {
            OrderHeaders = new OrderHeaders();
            orderDetails = new OrderDetails();
        }
        public OrderHeaders OrderHeaders { get; set; }
        public OrderDetails orderDetails { get; set; }
    }

    public class OrderDetails
    {
        public OrderDetails()
        {
            StockLines = new List<StockLines>();
        }

        public List<StockLines> StockLines { get; set; }
    }

    public class StockLines
    {
        public int PurchaseOrderLine { get; set; }
        public string LineActionType { get; set; }
        public string StockCode { get; set; }
        public string StockDescription { get; set; }
        public string OrderQty { get; set; }
        public string OrderUom { get; set; }
        public decimal Price { get; set; }
        public string PriceUom { get; set; }
        public string UserDefined { get; set; }
        public string ActualStockDescription { get; set; }
        public string SalesOrderLine { get; set; }
    }

    public class OrderHeaders
    {
        public string SalesOrder { get; set; }
        public string OrderActionType { get; set; }
        public string Customer { get; set; }
        public string OrderType { get; set; }

        public string CustomerPoNumber { get; set; }
        public string CustomerName { get; set; }
        public string ShipToAddr1 { get; set; }
        public string ShipToAddr2 { get; set; }
        public string ShipToAddr3 { get; set; }
        public string ShipToAddr4 { get; set; }
        public string ShipToPostalCode { get; set; }
    }

    public class Customer
    {
        public string CustomerCode { get; set; }
        public string Name { get; set; }
        public string ShipToAddr1 { get; set; }
        public string ShipToAddr2 { get; set; }
        public string ShipToAddr3 { get; set; }
        public string ShipToPostalCode { get; set; }
        public string ShortName { get; set; }
        public string Telephone { get; set; }
        public string AddTelephone { get; set; }
        public string Branch { get; set; }
        public string UserField2 { get; set; }

    }

    public class SysproCustomerModel
    {
        public SysproCustomerModel() { }
        public string Customer { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string ShipToAddr1 { get; set; }
        public string ShipToAddr2 { get; set; }
        public string ShipToAddr3 { get; set; }
        public string ShipToAddr4 { get; set; }
        public string ShipToAddr5 { get; set; }
        public string ShipPostalCode { get; set; }
        public string SoldToAddr1 { get; set; }
        public string SoldToAddr2 { get; set; }
        public string SoldToAddr3 { get; set; }
        public string SoldToAddr4 { get; set; }
        public string SoldToAddr5 { get; set; }
        public string SoldPostalCode { get; set; }
        public string Area { get; set; }
        public string Contact { get; set; }
        public string Telephone { get; set; }
        public string AddTelephone { get; set; }
        public string Email { get; set; }
        public string Branch { get; set; }
        public string SalesPerson { get; set; }
        public string StatementFormat { get; set; }
        public string TermsCode { get; set; }

    }
}
