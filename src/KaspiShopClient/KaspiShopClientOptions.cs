namespace KaspiShopClient;

/// <summary>
/// Configuration options for the Kaspi Shop API client.
/// </summary>
public class KaspiShopClientOptions
{
    /// <summary>
    /// The authentication token used for API requests.
    /// This token will be added to the X-Auth-Token header.
    /// </summary>
    public string? AuthToken { get; set; }

    /// <summary>
    /// The base address for the Kaspi Shop API.
    /// Defaults to "https://kaspi.kz/shop/api/" if not specified.
    /// </summary>
    public string BaseAddress { get; set; } = "https://kaspi.kz/shop/api/";

    /// <summary>
    /// Timeout for HTTP requests in seconds.
    /// Defaults to 30 seconds if not specified.
    /// </summary>
    public int TimeoutSeconds { get; set; } = 30;
}