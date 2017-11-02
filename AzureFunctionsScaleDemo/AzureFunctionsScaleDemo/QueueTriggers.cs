using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsScaleDemo
{
    public static class QueueTriggers
    {
        [FunctionName("QueueTrigger1")]
        public static async Task QueueTrigger1(
            [QueueTrigger("queue1", Connection = "queueConnection")]string myQueueItem,
            [Queue("queue2", Connection = "queueConnection")]IAsyncCollector<string> output,
            ILogger log)
        {
            await output.AddAsync("New Item 1");
            await output.AddAsync("New Item 2");
        }

        [FunctionName("QueueTrigger2")]
        public static async Task QueueTrigger2(
            [QueueTrigger("queue2", Connection = "queueConnection")]string myQueueItem,
            [Queue("queue1", Connection = "queueConnection")]IAsyncCollector<string> output,
            ILogger log)
        {
            await output.AddAsync("New Item 1");
            await output.AddAsync("New Item 2");
        }
    }
}
