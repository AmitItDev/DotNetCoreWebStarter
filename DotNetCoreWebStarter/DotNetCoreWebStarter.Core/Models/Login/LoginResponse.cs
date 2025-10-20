using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebStarter.Core.Models.Login
{
    public class LoginResponse
    {
        public bool Success { get; set; }

        public string? Token { get; set; }

        public string UserName { get; set; } = string.Empty;

        public List<string> Roles { get; set; } = new();
        public string Message { get; set; } = string.Empty;
    }
}
