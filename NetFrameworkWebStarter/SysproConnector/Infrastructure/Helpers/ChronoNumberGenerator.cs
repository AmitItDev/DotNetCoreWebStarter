using System;

namespace SysproConnector.Infrastructure.Helpers
{
    internal static class ChronoNumberGenerator
    {
        internal static int GetUniqueNumber()
        {
            var currentTimeStamp = DateTime.Now;
            
            var prefix = (currentTimeStamp.Year + currentTimeStamp.Day).ToString();
            var body   = currentTimeStamp.Millisecond.ToString();
            var suffix = (currentTimeStamp.Hour + currentTimeStamp.Minute + currentTimeStamp.Second).ToString();
            
            return Convert.ToInt32(prefix + body + suffix);
        }
    }
}
