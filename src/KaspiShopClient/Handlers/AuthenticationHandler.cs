using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace KaspiShopClient.Handlers;

/// <summary>
/// HTTP message handler that adds authentication token to request headers.
/// </summary>
public class AuthenticationHandler : DelegatingHandler
{
    private readonly ILogger<AuthenticationHandler> _logger;
    private readonly KaspiShopClientOptions _options;

    public AuthenticationHandler(
        ILogger<AuthenticationHandler> logger,
        IOptions<KaspiShopClientOptions> options,
        HttpMessageHandler? innerHandler = null)
        : base(innerHandler ?? new HttpClientHandler())
    {
        _logger = logger;
        _options = options.Value;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        // Add authentication token to headers if configured
        if (!string.IsNullOrEmpty(_options.AuthToken))
        {
            request.Headers.Add("X-Auth-Token", _options.AuthToken);
            _logger.LogDebug("Added X-Auth-Token header to request for {RequestUri}", request.RequestUri);
        }
        else
        {
            _logger.LogWarning("No authentication token configured for request to {RequestUri}", request.RequestUri);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}