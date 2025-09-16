using Microsoft.Extensions.Logging;

namespace KaspiShopClient.Handlers;

public class ExceptionHandler(ILogger<ExceptionHandler> logger) : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        try
        {
            return base.SendAsync(request, cancellationToken);
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            throw;
        }
    }
}