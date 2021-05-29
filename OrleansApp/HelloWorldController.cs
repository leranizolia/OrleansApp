using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orleans;


namespace OrleansApp
{

    public class HelloWorldController : Controller
    {

        private readonly IClusterClient clusterClient;

        public HelloWorldController(IClusterClient clusterClient)
        {
            this.clusterClient = clusterClient;
        }

        [HttpGet("/hello/{name}")]
        public async Task<IActionResult> Hello (string name)
        {
            var result = await clusterClient.GetGrain<IHelloWorldGrain>("Stu").SayHelloToAsync(name);
            var randomNumber = await clusterClient.GetGrain<IMyStatelessWorker>(0).ComputeNextNumberAsync();

            return Ok($"{result} {randomNumber}");
        }
    }
}
