using Microsoft.Extensions.Logging;

namespace KaspiShopClient.Handlers;

public class ExceptionHandler : DelegatingHandler
{
    private readonly ILogger<ExceptionHandler> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger used to log exception details.</param>
    public ExceptionHandler(ILogger<ExceptionHandler> logger)
    {
        _logger = logger;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        try
        {
            return base.SendAsync(request, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
    }
}