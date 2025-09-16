using System.Text.Json.Serialization;

namespace KaspiShopClient.Models;

/// <summary>
/// Представляет возможное значение характеристики товара в API магазина Kaspi.kz, включая его код и отображаемое имя.
/// <see cref="https://guide.kaspi.kz/partner/ru/shop/api/goods/q3218">Официальная документация API Kaspi.kz</see>
/// </summary>
public record ProductAttributeValue(
    /// <summary>
    /// Уникальный код, идентифицирующий значение характеристики (например, "мягкая").
    /// </summary>
    [property: JsonPropertyName("code")] string Code,
    
    
    /// <summary>
    /// Отображаемое имя значения характеристики (например, "мягкая").
    /// </summary>
    [property: JsonPropertyName("name")] string Name
);