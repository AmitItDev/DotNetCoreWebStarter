using SysproConnector.Managers;
using SysproConnector.Models;

namespace SysproConnector.Public
{
    public class Pricing
    {
        private PricingManager PricingManager;

        public Pricing(string webServiceUrl)
        {
            PricingManager = new PricingManager(webServiceUrl);
        }

        public ResponseModel GetPricing(string customerNumber, string stockCode, string quantity, string sessionId) 
            => PricingManager.QueryPricing(customerNumber, stockCode, quantity, sessionId);
    }
}
