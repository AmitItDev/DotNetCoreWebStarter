using SysproConnector.Models;

namespace SysproConnector.Managers
{
    internal class AuthenticationManager
    {
        private SysproManager SysproManager;

        internal AuthenticationManager(SysproManager sysproManager)
        {
            SysproManager = sysproManager;
        }

        internal ResponseModel Logon(bool isTest)             => SysproManager.Logon(isTest);

        internal bool IsLoggedIn(string sessionId) => SysproManager.IsLoggedOn(sessionId);

        internal void LogOff(string sessionId)     => SysproManager.Logoff(sessionId);
    }
}
