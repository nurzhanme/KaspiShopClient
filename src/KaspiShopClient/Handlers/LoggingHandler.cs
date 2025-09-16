using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace KaspiShopClient.Handlers;

public class LoggingHandler(ILogger<LoggingHandler> logger, HttpMessageHandler innerHandler)
    : DelegatingHandler(innerHandler ?? new HttpClientHandler())
{
    private readonly Stopwatch _stopwatch = new();

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Sending request to {request.RequestUri}");
        _stopwatch.Start();

        var response = await base.SendAsync(request, cancellationToken);
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
            
        _stopwatch.Stop();
        logger.LogInformation($"Request to {request.RequestUri} completed in {_stopwatch.ElapsedMilliseconds} ms");
        _stopwatch.Reset();

        return response;
    }
}