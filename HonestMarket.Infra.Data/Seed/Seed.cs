using HonestMarket.Domain.Entities;
using HonestMarket.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonestMarket.Infra.Data.Seed;

public static class Seed
{
    public static void SeedProduct(this HonestMarketContext context)
    {
        var entity = new List<Product>()
        {
            new Product()
            {
                Description = "Coca-Cola",
                Price = decimal.Parse("5.00")
            },
            new Product()
            {
                Description = "Água",
                Price = decimal.Parse("3.00")
            },
            new Product()
            {
                Description = "Água com gás",
                Price = decimal.Parse("3.00")
            },
        };

        foreach (var item in entity)
        {
            if (!context.Set<Product>().Any(c => c.Description == item.Description))
            {
                context.Set<Product>().Add(item);
            }
        }

        context.SaveChanges();
    }
}
