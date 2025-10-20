using SysproConnector.Managers;
using SysproConnector.Models;

namespace SysproConnector.Public
{
    public class Customer
    {
        private CustomerManager CustomerManager;

        public Customer(string webServiceUrl)
        {
            CustomerManager = new CustomerManager(webServiceUrl);
        }

        public ResponseModel GetFinancialInfo(string customerNumber, string sessionId) => CustomerManager.QueryCustomer(customerNumber, sessionId);
    }
}
