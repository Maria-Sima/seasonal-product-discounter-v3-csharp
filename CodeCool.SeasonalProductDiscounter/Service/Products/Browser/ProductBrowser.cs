﻿using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Service.Products.Provider;

namespace CodeCool.SeasonalProductDiscounter.Service.Products.Browser;

public class ProductBrowser : IProductBrowser
{
    private readonly IProductProvider _provider;

    public ProductBrowser(IProductProvider provider)
    {
        _provider = provider;
    }

    public IEnumerable<Product> GetAll()
    {
        return _provider.Products;
    }

    public IEnumerable<Product> GetByName(string name)
    {
        return _provider.Products.Where(p => p.Name.Contains(name));
    }

    public IEnumerable<Product> GetByColor(Color color)
    {
        return _provider.Products.Where(p => p.Color == color);
    }

    public IEnumerable<Product> GetBySeason(Season season)
    {
        return _provider.Products.Where(p => p.Season == season);
    }

    public IEnumerable<Product> GetByPriceSmallerThan(double price)
    {
        return _provider.Products.Where(p => p.Price < price);
    }

    public IEnumerable<Product> GetByPriceGreaterThan(double price)
    {
        return _provider.Products.Where(p => p.Price > price);
    }

    public IEnumerable<Product> GetByPriceRange(double minimumPrice, double maximumPrice)
    {
        return _provider.Products.Where(p => p.Price > minimumPrice && p.Price < maximumPrice);
    }

    public IEnumerable<IGrouping<string, Product>> GroupByName()
    {
        return _provider.Products.GroupBy(p => p.Name, p => p);
    }

    public IEnumerable<IGrouping<Color, Product>> GroupByColor()
    {
        return _provider.Products.GroupBy(p => p.Color, p => p);
    }

    public IEnumerable<IGrouping<Season, Product>> GroupBySeason()
    {
        return _provider.Products.GroupBy(p => p.Season, p => p);
    }

    public IEnumerable<IGrouping<PriceRange, Product>> GroupByPriceRange()
    {
        var minPrice = GetMinimumPrice();
        var maxPrice = GetMaximumPrice();
        var diff = maxPrice - minPrice;

        var cheap = new PriceRange(minPrice, minPrice + diff / 3);
        var medium = new PriceRange(cheap.Maximum, cheap.Maximum + diff / 3);
        var expensive = new PriceRange(medium.Maximum, medium.Maximum + diff / 3);

        return _provider.Products.GroupBy(p =>
        {
            if (cheap.Contains(p.Price))
            {
                return cheap;
            }

            if (medium.Contains(p.Price))
            {
                return medium;
            }

            return expensive;
        }, p => p);
    }

    private double GetMinimumPrice()
    {
        return _provider.Products.Min(p => p.Price);
    }

    private double GetMaximumPrice()
    {
        return _provider.Products.Max(p => p.Price);
    }

    public IEnumerable<Product> OrderByName()
    {
        return _provider.Products.OrderBy(p => p.Name);
    }

    public IEnumerable<Product> OrderByColor()
    {
        return _provider.Products.OrderBy(p => p.Name);
    }

    public IEnumerable<Product> OrderBySeason()
    {
        return _provider.Products.OrderBy(p => p.Name);
    }

    public IEnumerable<Product> OrderByPrice()
    {
        return _provider.Products.OrderBy(p => p.Name);
    }
}
