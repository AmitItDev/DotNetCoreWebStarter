namespace SysproConnector.Infrastructure.Messages
{
    internal static class LabourMessages
    {
        internal static string AllocateToJobSuccessStockedFabricated(string stockCode) =>
            $"Successfully allocated labour to job for OAPL Fabricated item {stockCode}";

        internal static string AllocateToJobFailedStockedFabricated(string stockCode)  =>
            $"Failed to allocate labour to job for OAPL Fabricated item {stockCode}";

        internal static string UpdateAllocationToJobSuccessStockedFabricated(string stockCode) =>
            $"Successfully updated labour allocation to job for OAPL Fabricated item {stockCode}";

        internal static string UpdateAllocationToJobFailedStockedFabricated(string stockCode) =>
            $"Failed to update labour allocation to job for OAPL Fabricated item {stockCode}";

        internal static string AllocateToJobFailed => "Failed to allocate labour to job";
    }
}
