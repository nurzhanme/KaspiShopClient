﻿using KaspiShopClient.Models;
using Refit;

namespace KaspiShopClient;

/// <summary>
/// Определяет методы для взаимодействия с API магазина Kaspi.kz, включая получение характеристик товаров и их возможных значений.
/// Все запросы включают заголовок X-Auth-Token для аутентификации, который добавляется автоматически через AuthenticationHandler.
/// </summary>
public interface IKaspiShopApi
{
    /// <summary>
    /// Получает список категорий товаров из API магазина Kaspi.kz для добавления товаров.
    /// <see href="https://guide.kaspi.kz/partner/ru/shop/api/goods/q3216">Официальная документация API Kaspi.kz</see>
    /// </summary>
    /// <returns>Задача, возвращающая список объектов <see cref="ProductCategory"/>, представляющих категории товаров и их коды.</returns>
    /// <exception cref="ApiException">Вызывается при сбое запроса API (например, из-за ошибки аутентификации).</exception>
    [Get("/products/classification/categories")]
    Task<List<ProductCategory>> GetProductCategoriesAsync();
    
    /// <summary>
    /// Получает список характеристик для указанной категории товаров из API магазина Kaspi.kz.
    /// <see cref="https://guide.kaspi.kz/partner/ru/shop/api/goods/q3217">Официальная документация API Kaspi.kz</see>
    /// </summary>
    /// <param name="categoryCode">Код категории товаров (например, "Master - Exercise notebooks"). Не должен быть пустым или null.</param>
    /// <returns>Задача, возвращающая список объектов <see cref="ProductAttribute"/>, представляющих характеристики категории.</returns>
    /// <exception cref="ApiException">Вызывается при сбое запроса API (например, из-за неверного кода категории или ошибки аутентификации).</exception>
    [Get("/products/classification/attributes?c={categoryCode}")]
    Task<List<ProductAttribute>> GetProductAttributesAsync(string categoryCode);

    /// <summary>
    /// Получает возможные значения для конкретной характеристики категории товаров из API магазина Kaspi.kz.
    /// <see cref="https://guide.kaspi.kz/partner/ru/shop/api/goods/q3218">Официальная документация API Kaspi.kz</see>
    /// </summary>
    /// <param name="categoryCode">Код категории товаров (например, "Master - Exercise notebooks"). Не должен быть пустым или null.</param>
    /// <param name="attributeCode">Код характеристики (например, "Exercise notebooks*Obsie harakteristiki.exercise notebooks*cover"). Не должен быть пустым или null.</param>
    /// <returns>Задача, возвращающая список объектов <see cref="ProductAttributeValue"/>, представляющих возможные значения характеристики.</returns>
    /// <exception cref="ApiException">Вызывается при сбое запроса API (например, из-за неверного кода категории или характеристики, или ошибки аутентификации).</exception>
    [Get("/products/classification/attribute/values?c={categoryCode}&a={attributeCode}")]
    Task<List<ProductAttributeValue>> GetProductAttributeValuesAsync(
        string categoryCode,
        string attributeCode);
}