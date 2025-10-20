namespace SysproConnector.Infrastructure.Messages
{
    internal static class AuthenticationMessages
    {
        internal static string SysproUserNotLoggedOn = "Internal Error: Syspro user is not logged in";

        internal static string CreatedNewSession(string newSessionId) => $"New Session ID created - {newSessionId}";
    }
}
