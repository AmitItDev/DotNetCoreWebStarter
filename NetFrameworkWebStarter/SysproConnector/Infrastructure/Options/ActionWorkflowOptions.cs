namespace SysproConnector.Infrastructure.Options
{
    internal static class ActionWorkflowOptions
    {
        internal static string Logon                               { get; } = "Logon";
        internal static string IsLoggedOn                          { get; } = "IsLoggedOn";
        internal static string CreateSalesOrder                    { get; } = "CreateSalesOrder";
        internal static string UpdateSalesOrder                    { get; } = "UpdateSalesOrder";
        internal static string UpdateOrderStatus                   { get; } = "UpdateOrderStatus";
        internal static string ConvertForwardOrderToScheduledOrder { get; } = "ConvertForwardOrderToScheduledOrder";
        internal static string CancelSalesOrder                    { get; } = "CancelSalesOrder";
        internal static string CreateUnappliedPayment              { get; } = "CreateUnappliedPayment";
        internal static string SaveJobNotes                        { get; } = "SaveJobNotes";
        internal static string PlaceJobOnHold                      { get; } = "PlaceJobOnHold";
        internal static string TakeJobOffOnHold                    { get; } = "TakeJobOffOnHold";
        internal static string GetUnitPrice                        { get; } = "GetUnitPrice";
        internal static string CreatePatient                       { get; } = "CreatePatient";
        internal static string UpdatePatient                       { get; } = "UpdatePatient";
        internal static string GetFunderInformation                { get; } = "GetFunderInformation";
        internal static string GetSalesOrderInfo                   { get; } = "GetSalesOrderInfo";
        internal static string GetSalesJobComment                  { get; } = "GetSalesJobComment";
    }
}
