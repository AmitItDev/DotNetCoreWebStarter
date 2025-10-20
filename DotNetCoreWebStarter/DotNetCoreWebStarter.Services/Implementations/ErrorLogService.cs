using DotNetCoreWebStarter.Core.Entities;
using DotNetCoreWebStarter.Data;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace DotNetCoreWebStarter.Core.Services
{
    public static class ErrorLogService
    {
        private static AppDbContext _context = null!;
        private static IHttpContextAccessor _httpContext = null!;

        /// <summary>
        /// Call this once at startup to initialize static service
        /// </summary>
        public static void Initialize(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContext = httpContextAccessor;
        }

        public static void Log(Exception ex, int? userId = null)
        {
            if (_context == null) throw new InvalidOperationException("ErrorLogService not initialized.");

            var error = new ErrorLog
            {
                ErrorDate = DateTime.UtcNow,
                LoginUserId = userId ?? GetCurrentUserId(),
                IPAddress = GetIPAddress(),
                ClientBrowser = GetUserAgent(),
                ErrorMessage = ex.Message,
                ErrorStackTrace = ex.StackTrace,
                URL = GetCurrentUrl(),
                URLReferrer = GetReferrer(),
                ErrorSource = ex.Source,
                ErrorTargetSite = ex.TargetSite?.ToString(),
                QueryString = _httpContext.HttpContext?.Request.QueryString.Value,
                PostData = GetPostData(),
                SessionInfo = GetSessionInfo()
            };

            _context.ErrorLogs.Add(error);
            _context.SaveChanges();
        }

        public static void Log(string message, string? stackTrace = null, int? userId = null, string? url = null)
        {
            if (_context == null) throw new InvalidOperationException("ErrorLogService not initialized.");

            var error = new ErrorLog
            {
                ErrorDate = DateTime.UtcNow,
                LoginUserId = userId ?? GetCurrentUserId(),
                IPAddress = GetIPAddress(),
                ClientBrowser = GetUserAgent(),
                ErrorMessage = message,
                ErrorStackTrace = stackTrace,
                URL = url ?? GetCurrentUrl(),
                URLReferrer = GetReferrer(),
                QueryString = _httpContext.HttpContext?.Request.QueryString.Value,
                PostData = GetPostData(),
                SessionInfo = GetSessionInfo()
            };

            _context.ErrorLogs.Add(error);
            _context.SaveChanges();
        }

        #region Helpers
        private static int? GetCurrentUserId()
        {
            if (_httpContext.HttpContext?.User?.Identity?.IsAuthenticated ?? false)
            {
                var idClaim = _httpContext.HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                if (idClaim != null && int.TryParse(idClaim.Value, out int userId))
                    return userId;
            }
            return null;
        }

        private static string? GetIPAddress() => _httpContext.HttpContext?.Connection?.RemoteIpAddress?.ToString();
        private static string? GetUserAgent() => _httpContext.HttpContext?.Request.Headers["User-Agent"].ToString();
        private static string? GetCurrentUrl() => _httpContext.HttpContext?.Request.Path;
        private static string? GetReferrer() => _httpContext.HttpContext?.Request.Headers["Referer"].ToString();

        private static string? GetPostData()
        {
            try
            {
                var request = _httpContext.HttpContext?.Request;
                if (request != null && request.Method == "POST")
                {
                    request.Body.Position = 0;
                    using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
                    var body = reader.ReadToEnd();
                    request.Body.Position = 0;
                    return body;
                }
            }
            catch { }
            return null;
        }

        private static string? GetSessionInfo()
        {
            var session = _httpContext.HttpContext?.Session;
            if (session == null) return null;

            var dict = new Dictionary<string, string?>();
            foreach (var key in session.Keys)
            {
                if (session.TryGetValue(key, out var val))
                    dict[key] = Encoding.UTF8.GetString(val);
            }
            return JsonSerializer.Serialize(dict);
        }
        #endregion
    }
}
