# KaspiShopClient

A .NET client library for interacting with the Kaspi.kz Shop API. This library provides easy access to product categories, attributes, and attribute values with built-in authentication and error handling.

## Features

- 🔐 **Automatic Authentication** - Built-in token-based authentication
- 📝 **Comprehensive Logging** - Request/response logging with configurable levels
- 🛡️ **Error Handling** - Robust error handling and exception management
- ⚙️ **Flexible Configuration** - Multiple configuration options (direct, options pattern, appsettings.json)
- 📊 **Strongly Typed** - Full IntelliSense support with detailed XML documentation
- 🏗️ **Dependency Injection** - Native support for .NET dependency injection

## Installation

Install the package via NuGet Package Manager:

```bash
dotnet add package KaspiShopClient
```

Or via Package Manager Console:

```powershell
Install-Package KaspiShopClient
```

## Quick Start

### 1. Basic Setup

```csharp
using Microsoft.Extensions.DependencyInjection;
using KaspiShopClient;

// Register the client with dependency injection
services.AddKaspiShopClient("your-auth-token-here");
```

### 2. Using the Client

```csharp
public class ProductService
{
    private readonly IKaspiShopApi _kaspiApi;

    public ProductService(IKaspiShopApi kaspiApi)
    {
        _kaspiApi = kaspiApi;
    }

    public async Task<List<ProductCategory>> GetCategoriesAsync()
    {
        return await _kaspiApi.GetProductCategoriesAsync();
    }

    public async Task<List<ProductAttribute>> GetAttributesAsync(string categoryCode)
    {
        return await _kaspiApi.GetProductAttributesAsync(categoryCode);
    }

    public async Task<List<ProductAttributeValue>> GetAttributeValuesAsync(
        string categoryCode, 
        string attributeCode)
    {
        return await _kaspiApi.GetProductAttributeValuesAsync(categoryCode, attributeCode);
    }
}
```

## Configuration Options

### Option 1: Direct Token

```csharp
services.AddKaspiShopClient("your-auth-token-here");
```

### Option 2: Configuration Object

```csharp
services.AddKaspiShopClient(options =>
{
    options.AuthToken = "your-auth-token-here";
    options.BaseAddress = "https://kaspi.kz/shop/api/";
    options.TimeoutSeconds = 60;
});
```

### Option 3: appsettings.json

```json
{
  "KaspiShopClient": {
    "AuthToken": "your-auth-token-here",
    "BaseAddress": "https://kaspi.kz/shop/api/",
    "TimeoutSeconds": 30
  }
}
```

```csharp
services.Configure<KaspiShopClientOptions>(configuration.GetSection("KaspiShopClient"));
services.AddKaspiShopClient();
```

## API Reference

### IKaspiShopApi

| Method | Description | Parameters |
|--------|-------------|------------|
| `GetProductCategoriesAsync()` | Get all product categories | None |
| `GetProductAttributesAsync(categoryCode)` | Get attributes for a category | `categoryCode`: Category identifier |
| `GetProductAttributeValuesAsync(categoryCode, attributeCode)` | Get possible values for an attribute | `categoryCode`: Category identifier<br>`attributeCode`: Attribute identifier |

### Models

- **ProductCategory**: Represents a product category
- **ProductAttribute**: Represents a product attribute/characteristic
- **ProductAttributeValue**: Represents possible values for an attribute

## Configuration Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `AuthToken` | `string?` | `null` | Authentication token for API requests |
| `BaseAddress` | `string` | `"https://kaspi.kz/shop/api/"` | Base URL for the Kaspi Shop API |
| `TimeoutSeconds` | `int` | `30` | HTTP request timeout in seconds |

## Error Handling

The library includes comprehensive error handling:

- **ApiException**: Thrown for API-related errors (authentication, invalid parameters, etc.)
- **HttpRequestException**: Thrown for network-related errors
- **TimeoutException**: Thrown when requests exceed the configured timeout

All exceptions include detailed error information to help with debugging.

## Logging

The library provides detailed logging for:

- Authentication token validation
- HTTP request/response details
- API errors and exceptions
- Performance metrics

Configure logging levels in your application to control verbosity.

## Requirements

- **.NET 9.0** (STS)
- **.NET 8.0** (LTS)
- **.NET Standard 2.1**
- **.NET Standard 2.0**
- Valid Kaspi.kz Shop API authentication token

## Documentation

For detailed API documentation and examples, see:

- [Token Authentication Guide](TOKEN_AUTHENTICATION.md)
- [Official Kaspi.kz API Documentation](https://guide.kaspi.kz/partner/ru/shop/api/)

## License

This project is licensed under the MIT License.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Support

If you encounter any issues or have questions, please [open an issue](https://github.com/nurzhanme/KaspiShopClient/issues) on GitHub.