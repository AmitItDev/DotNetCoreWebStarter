namespace DotNetCoreWebStarter.Core.Entities
{
    public class ErrorLog
    {
        public int ErrorLogId { get; set; }
        public DateTime? ErrorDate { get; set; }

        // FK to ApplicationUser if needed (else keep as LoginID int only)
        public int? LoginUserId { get; set; }

        public string? IPAddress { get; set; }
        public string? ClientBrowser { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ErrorStackTrace { get; set; }
        public string? URL { get; set; }
        public string? URLReferrer { get; set; }
        public string? ErrorSource { get; set; }
        public string? ErrorTargetSite { get; set; }
        public string? QueryString { get; set; }
        public string? PostData { get; set; }
        public string? SessionInfo { get; set; }
    }
}
