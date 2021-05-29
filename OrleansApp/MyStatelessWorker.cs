using System;
using System.Threading.Tasks;
using Orleans;
using Orleans.Concurrency;

namespace OrleansApp
{
    public interface IMyStatelessWorker: IGrainWithIntegerKey
    {
        Task<double> ComputeNextNumberAsync();
    }

    [StatelessWorker]
    public class MyStatelessWorker : Grain, IMyStatelessWorker
    {
        public async Task<double> ComputeNextNumberAsync()
        {
            var rnd = new Random();

            await Task.Delay(rnd.Next(1000, 5000));

            return rnd.NextDouble();
        }
    }
}
