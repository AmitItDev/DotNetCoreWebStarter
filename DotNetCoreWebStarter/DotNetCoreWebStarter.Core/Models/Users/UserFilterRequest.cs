namespace DotNetCoreWebStarter.Core.Models.Users
{
    public class UserFilterRequest
    {
        public string? Search { get; set; }
        public List<string>? Roles { get; set; }
        public List<string>? Status { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SortField { get; set; } = "Username";
        public string SortDir { get; set; } = "asc";
    }
}
