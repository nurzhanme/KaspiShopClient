using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace KaspiShopClient.Handlers;

public class LoggingHandler : DelegatingHandler
{
    private readonly Stopwatch _stopwatch = new();
    private readonly ILogger<LoggingHandler> _logger;

    public LoggingHandler(ILogger<LoggingHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Sending request to {request.RequestUri}");
        _stopwatch.Start();

        var response = await base.SendAsync(request, cancellationToken);
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
            
        _stopwatch.Stop();
        _logger.LogInformation($"Request to {request.RequestUri} completed in {_stopwatch.ElapsedMilliseconds} ms");
        _stopwatch.Reset();

        return response;
    }
}