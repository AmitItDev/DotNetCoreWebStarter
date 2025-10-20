
using System;

namespace DotNetCoreWebStarter.Core.Models.Users
{
    public class UserResponse
    {
        public int total_count { get; set; }
        public List<UserDto> data { get; set; } = new();
        public int last_page { get; set; } 
    }

    public class UserDto
    {
        private static readonly Random _random = new();
        public int UserId { get; set; } 
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Status { get; set; } = "";

        //For alginemnt test purpose only 
        // Random LastLogin within the last 30 days
        public DateTime LastLogin { get; set; } =
            DateTime.UtcNow.AddDays(-_random.Next(0, 30)).AddHours(-_random.Next(0, 24));

        // Random HourlyRate between 15.00 and 120.00
        public decimal HourlyRate { get; set; } =
            Math.Round((decimal)(_random.NextDouble() * (120 - 15) + 15), 2);
    }
}
