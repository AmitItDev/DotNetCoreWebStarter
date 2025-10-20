namespace SysproConnector.Infrastructure.Settings
{
    internal static class SysproGeneralSettings
    {
        internal static string Language                   { get; } = "EN";

        internal static string PostXmlComment             { get; } = @"version=""1.0"" encoding=""Windows-1252";

        internal static string LogonProfileExpiredMessage { get; } = "The supplied UserID is invalid. Either you were not logged in; or your session has expired. You will need to logon again.";
    }
}
