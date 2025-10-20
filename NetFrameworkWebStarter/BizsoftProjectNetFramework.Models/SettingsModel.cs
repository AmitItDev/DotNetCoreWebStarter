namespace NetFrameworkWebStarter.Models
{
    public class SettingsModel
    {
        public int SettingId { get; set; }
        public string SysproOperator { get; set; }
        public string SysproOperatorPassword { get; set; }
        public string SysproCompany { get; set; }
        public string SysproCompanyPassword { get; set; }
        public string WebserviceURL { get; set; }
        public int SysproWCFBinding { get; set; }
    }
}
