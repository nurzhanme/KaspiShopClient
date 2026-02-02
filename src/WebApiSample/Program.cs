using KaspiShopClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddKaspiShopClient(x =>
{
    x.AuthToken = "YOUR_AUTH_TOKEN";
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Sample endpoint to get all product categories
app.MapGet("/kaspi/product-categories", async (IKaspiShopApi kaspiApi) =>
    {
        try
        {
            var categories = await kaspiApi.GetProductCategoriesAsync();
            return Results.Ok(new
            {
                CategoryCount = categories.Count,
                Categories = categories.Take(20) // Limit to first 20 for display
            });
        }
        catch (Exception ex)
        {
            return Results.Problem(
                detail: ex.Message,
                title: "Error fetching product categories",
                statusCode: 500
            );
        }
    })
    .WithName("GetProductCategories")
    .WithSummary("Get all product categories")
    .WithDescription("Fetches all available product categories from Kaspi Shop API.");

// Sample endpoint to demonstrate getting product attributes
app.MapGet("/kaspi/product-attributes/{categoryCode}", async (string categoryCode, IKaspiShopApi kaspiApi) =>
    {
        try
        {
            var attributes = await kaspiApi.GetProductAttributesAsync(categoryCode);
            return Results.Ok(new
            {
                CategoryCode = categoryCode,
                AttributeCount = attributes.Count,
                Attributes = attributes.Take(10) // Limit to first 10 for display
            });
        }
        catch (Exception ex)
        {
            return Results.Problem(
                detail: ex.Message,
                title: "Error fetching product attributes",
                statusCode: 500
            );
        }
    })
    .WithName("GetProductAttributes")
    .WithSummary("Get product attributes for a category")
    .WithDescription("Fetches product attributes from Kaspi Shop API for the specified category code. Example: 'Master - Smartphones'");

// Sample endpoint to demonstrate getting attribute values
app.MapGet("/kaspi/attribute-values/{categoryCode}/{attributeCode}", async (string categoryCode, string attributeCode, IKaspiShopApi kaspiApi) =>
    {
        try
        {
            var values = await kaspiApi.GetProductAttributeValuesAsync(categoryCode, attributeCode);
            return Results.Ok(new
            {
                CategoryCode = categoryCode,
                AttributeCode = attributeCode,
                ValueCount = values.Count,
                Values = values.Take(10) // Limit to first 10 for display
            });
        }
        catch (Exception ex)
        {
            return Results.Problem(
                detail: ex.Message,
                title: "Error fetching attribute values",
                statusCode: 500
            );
        }
    })
    .WithName("GetAttributeValues")
    .WithSummary("Get attribute values for a specific attribute")
    .WithDescription("Fetches possible values for a specific product attribute from Kaspi Shop API.");

app.Run();
