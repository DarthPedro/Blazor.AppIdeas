using Blazor.AppIdeas.Converters.Services;
using Blazor.AppIdeas.Converters.ViewModels;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blazor.AppIdeas.Converters
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            };
            builder.Services.AddScoped(sp => httpClient);

            // add services and view models to DI container.
            builder.Services.AddSingleton<ICurrencyServiceClient>(
                sp => new CurrencyServiceClient(httpClient));

            builder.Services.AddTransient<RomanDecimalConverter>();
            builder.Services.AddTransient<NumberConverterViewModel>();
            builder.Services.AddTransient<DollarCentsConverterViewModel>();
            builder.Services.AddTransient<CurrencyConverterViewModel>();
            builder.Services.AddTransient<JsonCsvConverterViewModel>();

            await builder.Build().RunAsync();
        }
    }
}
