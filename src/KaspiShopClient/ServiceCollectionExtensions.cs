using KaspiShopClient.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace KaspiShopClient;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddKaspiShopOffersClient(this IServiceCollection services)
    {
        services
            .AddTransient<HttpMessageHandler, HttpClientHandler>()
            .AddScoped<LoggingHandler>()
            .AddScoped<ExceptionHandler>();

        services
            .AddRefitClient<IKaspiShopApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://kaspi.kz/shop/api/"))
            .AddHttpMessageHandler<LoggingHandler>()
            .AddHttpMessageHandler<ExceptionHandler>();
        return services;
    }
}