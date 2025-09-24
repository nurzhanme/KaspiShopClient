using System.Text.Json.Serialization;

namespace KaspiShopClient.Contracts.Models;

/// <summary>
/// Представляет возможное значение характеристики товара в API магазина Kaspi.kz, включая его код и отображаемое имя.
/// <see cref="https://guide.kaspi.kz/partner/ru/shop/api/goods/q3218">Официальная документация API Kaspi.kz</see>
/// </summary>
public record ProductAttributeValue
{
    /// <summary>
    /// Уникальный код, идентифицирующий значение характеристики (например, "мягкая").
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }


    /// <summary>
    /// Отображаемое имя значения характеристики (например, "мягкая").
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }
}