using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.ServiceBus.Messaging;

using System;
using System.Text;

namespace EXP.Functions
{
    public static class EventHubConsumer
    {
        [FunctionName("EventHubConsumer")]
        public static void Run([EventHubTrigger("%EventHubName%", Connection ="EventHubConnection")]EventData eventData, TraceWriter log)
        {
            String message = Encoding.UTF8.GetString(eventData.GetBytes());
            log.Info("============================");
            log.Info($"CONSUMER. Message: '{message}'");
            log.Info($"CONSUMER. Partition key: '{eventData.PartitionKey}'");
            log.Info("============================");
        }
    }
}