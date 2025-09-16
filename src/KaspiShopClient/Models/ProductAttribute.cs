using System.Text.Json.Serialization;

namespace KaspiShopClient.Models;

/// <summary>
/// Представляет характеристику категории товаров в API магазина Kaspi.kz, включая её код, тип и ограничения.
/// <see cref="https://guide.kaspi.kz/partner/ru/shop/api/goods/q3217">Официальная документация API Kaspi.kz</see>
/// </summary>
public record ProductAttribute(
    /// <summary>
    /// Уникальный код, идентифицирующий характеристику (например, "Exercise notebooks*Obsie harakteristiki.exercise notebooks*cover").
    /// </summary>
    [property: JsonPropertyName("code")] string Code,
    
    /// <summary>
    /// Тип данных характеристики (например, "enum", "boolean", "string", "number").
    /// </summary>
    [property: JsonPropertyName("type")] string Type,
    
    /// <summary>
    /// Указывает, можно ли задать несколько значений для характеристики.
    /// </summary>
    [property: JsonPropertyName("multiValued")] bool MultiValued,
    
    /// <summary>
    /// Указывает, является ли характеристика обязательной для заполнения.
    /// </summary>
    [property: JsonPropertyName("mandatory")] bool Mandatory
);