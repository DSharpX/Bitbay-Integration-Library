using System;

namespace BitBayIntegration.Coverters
{
    public class TimeConverter
    {
        public static long GetUnixTimestamp()
        {
            return (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
        }
    }
}
