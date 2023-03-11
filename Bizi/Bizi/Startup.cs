using Bizi.Builders;
using Bizi.Builders.Interfaces;
using Bizi.Services;
using Bizi.Services.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Bizi.Startup))]

namespace Bizi
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ITableClientFactory, TableClientFactory>();
            builder.Services.AddScoped<IProductItemBuilder, ProductItemBuilder>();
        }
    }
}