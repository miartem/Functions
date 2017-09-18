using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace EXP.Functions.ScheduledTask
{
    public static class LogCurrentTime
    {
        [FunctionName("LogCurrentTime")]
        public static void Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"Current time is: {DateTime.Now}");
        }
    }
}
