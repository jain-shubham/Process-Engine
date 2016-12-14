using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine;

namespace Engine.JobScheduler
{
    class Util
    {
        /// <summary>
        /// Utility method to get the time defference(TimeSpan) from the current system time.
        /// </summary>
        /// <param name="time">Input time</param>
        /// <returns>time defference(TimeSpan)</returns>
        public static TimeSpan TimeSpanFromNow(DateTime time)
        {
            return time - DateTime.Now;       // exception handling required
        }
    }
}
