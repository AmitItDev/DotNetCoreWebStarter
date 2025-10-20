using SysproConnector.Managers;
using SysproConnector.Models;

namespace SysproConnector.Public
{
    public class Authentication
    {
        private AuthenticationManager AuthenticationManager;

        public Authentication(string webServiceUrl)
        {
            AuthenticationManager = new AuthenticationManager(webServiceUrl);
        }

        public ResponseModel Logon(string company, string companyPassword, string user, string password, string EnetURL) => AuthenticationManager.Logon(company, companyPassword, user, password, EnetURL);
    }
}
