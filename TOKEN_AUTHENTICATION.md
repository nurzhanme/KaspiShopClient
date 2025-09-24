# Kaspi Shop Client - Token Authentication

This document explains how to use the token authentication feature in the Kaspi Shop Client.

## Usage Examples

### 1. Basic Usage with Token

```csharp
using Microsoft.Extensions.DependencyInjection;
using KaspiShopClient;

// Register the client with an authentication token
services.AddKaspiShopOffersClient("your-auth-token-here");
```

### 2. Configuration with Options

```csharp
using Microsoft.Extensions.DependencyInjection;
using KaspiShopClient;

// Register the client with custom configuration
services.AddKaspiShopOffersClient(options =>
{
    options.AuthToken = "your-auth-token-here";
    options.BaseAddress = "https://kaspi.kz/shop/api/";
    options.TimeoutSeconds = 60; // Optional: custom timeout
});
```

### 3. Configuration via appsettings.json

First, add the configuration to your `appsettings.json`:

```json
{
  "KaspiShopClient": {
    "AuthToken": "your-auth-token-here",
    "BaseAddress": "https://kaspi.kz/shop/api/",
    "TimeoutSeconds": 30
  }
}
```

Then register the client:

```csharp
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KaspiShopClient;

// Bind configuration and register the client
services.Configure<KaspiShopClientOptions>(configuration.GetSection("KaspiShopClient"));
services.AddKaspiShopOffersClient();
```

### 4. Using the Client

```csharp
using KaspiShopClient;

public class ProductService
{
    private readonly IKaspiShopApi _kaspiApi;

    public ProductService(IKaspiShopApi kaspiApi)
    {
        _kaspiApi = kaspiApi;
    }

    public async Task<List<ProductAttribute>> GetProductAttributesAsync(string categoryCode)
    {
        // The authentication token will be automatically added to the request headers
        return await _kaspiApi.GetProductAttributesAsync(categoryCode);
    }
}
```

## Features

- **Automatic Token Management**: The `AuthenticationHandler` automatically adds the `X-Auth-Token` header to all requests
- **Flexible Configuration**: Multiple ways to configure the client (direct token, options pattern, configuration binding)
- **Logging Support**: Built-in logging for authentication and request tracking
- **Error Handling**: Comprehensive error handling through the existing `ExceptionHandler`

## Configuration Options

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `AuthToken` | `string?` | `null` | The authentication token for API requests |
| `BaseAddress` | `string` | `"https://kaspi.kz/shop/api/"` | The base URL for the Kaspi Shop API |
| `TimeoutSeconds` | `int` | `30` | HTTP request timeout in seconds |

## Notes

- If no authentication token is provided, a warning will be logged
- The token is added to the `X-Auth-Token` header as required by the Kaspi Shop API
- All existing functionality remains unchanged - this is a backwards-compatible enhancement