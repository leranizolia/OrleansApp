using System;
using System.Threading.Tasks;
using Orleans;

namespace OrleansApp.CallFilters
{
    public class ConsoleWritingOutgoingCallFilter : IOutgoingGrainCallFilter
    {
        public ConsoleWritingOutgoingCallFilter()
        {
        }

        public async Task Invoke(IOutgoingGrainCallContext context)
        {
            Console.WriteLine("Hello outgoing grain call filter - start");
            await context.Invoke();
            Console.WriteLine("Hello outgoing grain call filter - end");
        }
    }
}

