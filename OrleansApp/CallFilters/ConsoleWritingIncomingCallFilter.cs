using System;
using System.Threading.Tasks;
using Orleans;

namespace OrleansApp.CallFilters
{
    public class ConsoleWritingIncomingCallFilter: IIncomingGrainCallFilter
    {
        public ConsoleWritingIncomingCallFilter()
        {
        }

        public async Task Invoke(IIncomingGrainCallContext context)
        {
            Console.WriteLine("Hello incoming grain call filter - start"); 
            await context.Invoke();
            Console.WriteLine("Hello incoming grain call filter - end");
        }
    }
}
