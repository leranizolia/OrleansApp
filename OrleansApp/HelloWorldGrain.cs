 using System;
using System.Threading.Tasks;
using Orleans;
using Orleans.Providers;
using Orleans.Runtime;

namespace OrleansApp
{
    public interface IHelloWorldGrain : IGrainWithStringKey
    {
        Task<string> SayHelloToAsync(string name);
    }

    [StorageProvider(ProviderName = "OrleansStorage")]
    public class HelloWorldGrain : Grain<HelloState>, IHelloWorldGrain, IRemindable
    {
        private IDisposable _timer;

        public async Task<string> SayHelloToAsync(string name)
        {
            var count = State.InvocationCount++;

            await WriteStateAsync();

            return $"Hello {name} from {this.GetPrimaryKeyString()} - I' ve said hello {count} times";
        }

        public override async Task OnActivateAsync()
        {
            await RegisterOrUpdateReminder("GrainReminder", TimeSpan.FromSeconds(5), TimeSpan.FromMinutes(1));

            await base.OnActivateAsync();
        }

        public Task ReceiveReminder(string reminderName, TickStatus status)
        {
            if ("GrainReminder".Equals(reminderName))
                Console.WriteLine("Hello world");

            return Task.CompletedTask;
        }

        //public override Task OnActivateAsync()
        //{
        //    _timer = RegisterTimer(state =>
        //    {
        //        Console.WriteLine("Hello world");
        //        return Task.CompletedTask;
        //   }, null, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(1));
        //
        //    return base.OnActivateAsync();
        //}
    }

    public class HelloState
    {
        public int InvocationCount { get; set; }
    }
}

