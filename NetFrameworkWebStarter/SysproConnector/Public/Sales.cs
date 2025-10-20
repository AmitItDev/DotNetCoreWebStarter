using SysproConnector.Managers;
using SysproConnector.Models;

namespace SysproConnector.Public
{
    public class Sales
    {
        private SalesManager SaleManager;

        public Sales(string webServiceUrl)
        {
            SaleManager = new SalesManager(webServiceUrl);
        }

        public ResponseModel Post(InvoiceInputModel saleToPost, string sessionId) => SaleManager.PostSales(saleToPost, sessionId);
    }
}
