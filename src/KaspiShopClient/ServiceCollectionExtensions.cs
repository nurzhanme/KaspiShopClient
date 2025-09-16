using KaspiShopClient.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Refit;

namespace KaspiShopClient;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the Kaspi Shop API client to the service collection with default configuration.
    /// </summary>
    /// <param name="services">The service collection to add the client to.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddKaspiShopClient(this IServiceCollection services)
    {
        return services.AddKaspiShopClient(_ => { });
    }

    /// <summary>
    /// Adds the Kaspi Shop API client to the service collection with default configuration.
    /// </summary>
    /// <param name="services">The service collection to add the client to.</param>
    /// <returns>The service collection for chaining.</returns>
    [Obsolete("Use AddKaspiShopClient instead")]
    public static IServiceCollection AddKaspiShopOffersClient(this IServiceCollection services)
    {
        return services.AddKaspiShopClient(_ => { });
    }

    /// <summary>
    /// Adds the Kaspi Shop API client to the service collection with custom configuration.
    /// </summary>
    /// <param name="services">The service collection to add the client to.</param>
    /// <param name="configureOptions">Action to configure the client options.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddKaspiShopClient(
        this IServiceCollection services,
        Action<KaspiShopClientOptions> configureOptions)
    {
        // Configure options
        services.Configure(configureOptions);

        // Register handlers as transient (required for HttpMessageHandler)
        services.AddTransient<AuthenticationHandler>();
        services.AddTransient<LoggingHandler>();
        services.AddTransient<ExceptionHandler>();

        // Register Refit client with configured options
        services
            .AddRefitClient<IKaspiShopApi>()
            .ConfigureHttpClient((serviceProvider, client) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<KaspiShopClientOptions>>().Value;
                client.BaseAddress = new Uri(options.BaseAddress);
                client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
            })
            .AddHttpMessageHandler<AuthenticationHandler>()
            .AddHttpMessageHandler<LoggingHandler>()
            .AddHttpMessageHandler<ExceptionHandler>();
        
        return services;
    }

    /// <summary>
    /// Adds the Kaspi Shop API client to the service collection with a specific authentication token.
    /// </summary>
    /// <param name="services">The service collection to add the client to.</param>
    /// <param name="authToken">The authentication token to use for API requests.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddKaspiShopClient(
        this IServiceCollection services,
        string authToken)
    {
        return services.AddKaspiShopClient(options => options.AuthToken = authToken);
    }

    /// <summary>
    /// Adds the Kaspi Shop API client to the service collection with custom configuration.
    /// </summary>
    /// <param name="services">The service collection to add the client to.</param>
    /// <param name="configureOptions">Action to configure the client options.</param>
    /// <returns>The service collection for chaining.</returns>
    [Obsolete("Use AddKaspiShopClient instead")]
    public static IServiceCollection AddKaspiShopOffersClient(
        this IServiceCollection services,
        Action<KaspiShopClientOptions> configureOptions)
    {
        return services.AddKaspiShopClient(configureOptions);
    }

    /// <summary>
    /// Adds the Kaspi Shop API client to the service collection with a specific authentication token.
    /// </summary>
    /// <param name="services">The service collection to add the client to.</param>
    /// <param name="authToken">The authentication token to use for API requests.</param>
    /// <returns>The service collection for chaining.</returns>
    [Obsolete("Use AddKaspiShopClient instead")]
    public static IServiceCollection AddKaspiShopOffersClient(
        this IServiceCollection services,
        string authToken)
    {
        return services.AddKaspiShopClient(authToken);
    }
}