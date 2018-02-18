using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Utility.Time
{
    public class DateTimeUtil
    {
        public static int GetCurrentTimeStamp()
        {
            return GetTimeStamp(DateTime.Now);
        }

        public static int GetTimeStamp(DateTime datetime)
        {
            System.DateTime startTime = System.TimeZoneInfo.ConvertTimeToUtc(new System.DateTime(1970, 1, 1));
            return (int)(datetime - startTime).TotalSeconds;
        }
    }
}
