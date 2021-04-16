using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using StkMS.Contracts;
using StkMS.Services;

namespace StkMS
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IMapper, Mapper>();
            builder.Services.AddScoped<IStock, Stock>();
            builder.Services.AddScoped<IInventory, Inventory>();

            await builder.Build().RunAsync().ConfigureAwait(true);
        }
    }
}