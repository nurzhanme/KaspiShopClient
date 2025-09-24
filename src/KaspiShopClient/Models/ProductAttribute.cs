using System.Text.Json.Serialization;

namespace KaspiShopClient.Models;

/// <summary>
/// Представляет характеристику категории товаров в API магазина Kaspi.kz, включая её код, тип и ограничения.
/// <see cref="https://guide.kaspi.kz/partner/ru/shop/api/goods/q3217">Официальная документация API Kaspi.kz</see>
/// </summary>
public class ProductAttribute
{
    /// <summary>
    /// Уникальный код, идентифицирующий характеристику (например, "Exercise notebooks*Obsie harakteristiki.exercise notebooks*cover").
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }
    
    /// <summary>
    /// Тип данных характеристики (например, "enum", "boolean", "string", "number").
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }
    
    /// <summary>
    /// Указывает, можно ли задать несколько значений для характеристики.
    /// </summary>
    [JsonPropertyName("multiValued")]
    public bool MultiValued { get; set; }
    
    /// <summary>
    /// Указывает, является ли характеристика обязательной для заполнения.
    /// </summary>
    [JsonPropertyName("mandatory")]
    public bool Mandatory { get; set; }
}