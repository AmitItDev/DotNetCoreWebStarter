
namespace DotNetCoreWebStarter.Core.Interfaces
{
    public interface IErrorLogService
    {
        Task LogAsync(Exception ex, int? userId = null);
        Task LogAsync(string message, string? stackTrace = null, int? userId = null, string? url = null);
    }

}
