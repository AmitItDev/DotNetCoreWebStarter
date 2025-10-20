namespace SysproConnector.Infrastructure
{
    public static class OrderStatusOption
    {
        public static string DetermineFunder        { get; } = "Determine Funder";
        public static string AwaitingFunderApproval { get; } = "Awaiting Funder Approval";
        public static string FunderApproved         { get; } = "Funder Approved";
        public static string OnHold                 { get; } = "On Hold";
        public static string SalesOrderInProgress   { get; } = "Sales Order In Progress";
        public static string ReadyForInvoicing      { get; } = "Ready For Invoicing";
        public static string ReadyToInvoice         { get; } = "Ready To Invoice";
        public static string FollowUp               { get; } = "Follow Up";
        public static string Cancelled              { get; } = "Cancelled";
    }
}
