﻿using CodeCool.SeasonalProductDiscounter.Model.Discounts;
using CodeCool.SeasonalProductDiscounter.Model.Offers;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Discounts;

public class DiscounterService : IDiscounterService
{
    private readonly IDiscountProvider _discountProvider;

    public DiscounterService(IDiscountProvider discountProvider)
    {
        _discountProvider = discountProvider;
    }

    public Offer GetOffer(Product product, DateTime date)
    {
        List<IDiscount> applicable = FindApplicableIDiscounts(product, date);
        double price = CalculateFinalPrice(product, applicable);
        return new Offer(product, date, applicable, price);
    }

    private List<IDiscount> FindApplicableIDiscounts(Product product, DateTime date)
    {
        List<IDiscount> accepted = new();

        foreach (var discount in _discountProvider.Discounts)
        {
            if (discount.Accepts(product, date))
            {
                accepted.Add(discount);
            }
        }

        return accepted;
    }

    private double CalculateFinalPrice(Product product, List<IDiscount> discounts)
    {
        double discountSum = SumDiscounts(discounts);

        double rate = (100 - discountSum) / 100;
        return discountSum == 0.0 ? product.Price : product.Price * rate;
    }

    private double SumDiscounts(List<IDiscount> discounts)
    {
        double discountSum = 0;
        foreach (var discount in discounts)
        {
            discountSum += discount.Rate;
        }

        return discountSum;
    }
}
