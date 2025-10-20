namespace SysproConnector.Infrastructure
{
    internal static class DynamicSessionStorage
    {
        internal static string GlobalRequestConnectorData  { get; set; } = string.Empty;
        internal static string GlobalAssistedSearchParam   { get; set; } = string.Empty;
        internal static string GlobalTransactionReference  { get; set; } = string.Empty;
        internal static string GlobalOperator              { get; set; } = string.Empty;
    }
}
