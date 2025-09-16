using System.Text.Json.Serialization;

namespace KaspiShopClient.Models;

/// <summary>
/// Представляет категорию товаров в API магазина Kaspi.kz, включая её код и название.
/// <see href="https://guide.kaspi.kz/partner/ru/shop/api/goods/q3216">Официальная документация API Kaspi.kz</see>
/// </summary>
public record ProductCategory(
    /// <summary>
    /// Уникальный код категории для API-запросов (например, "Master - Exercise notebooks").
    /// </summary>
    [property: JsonPropertyName("code")] string Code,

    /// <summary>
    /// Название категории в магазине Kaspi.kz (например, "Тетради").
    /// </summary>
    [property: JsonPropertyName("title")] string Title
);