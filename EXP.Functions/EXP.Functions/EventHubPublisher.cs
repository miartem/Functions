using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.ServiceBus.Messaging;

using System;
using System.Text;

namespace EXP.Functions
{
    public static class EventHubPublisher
    {
        [FunctionName("EventHubPublisher")]
        public static void Run([TimerTrigger("*/2 * * * * *")] TimerInfo myTimer, [EventHub("%EventHubName%", Connection = "EventHubConnection")] out EventData eventData, TraceWriter log)
        {
            string message = $"Current time is: {DateTime.Now}";
            eventData = new EventData(Encoding.UTF8.GetBytes(message))
            {
                PartitionKey = Math.Ceiling((DateTime.Now.Second / 10d)).ToString()
            };

            log.Info("============================");
            log.Info($"PUBLISHER. Message: '{message}'");
            log.Info($"PUBLISHER. Partition key: '{eventData.PartitionKey}'");
            log.Info("============================");
        }
    }
}
