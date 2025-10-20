namespace SysproConnector.Models
{
    public class LoginInputModel
    {
        public string CompanyCode      { get; set; }

        public string CompanyPassword  { get; set; }

        public string Operator         { get; set; }

        public string OperatorPassword { get; set; }

        public string WebServiceUrl    { get; set; }

        public string WMSUser          { get; set; }

    }
}