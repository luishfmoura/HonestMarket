using HonestMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonestMarket.Infra.Data.Context;

public class HonestMarketContextFactory : IDesignTimeDbContextFactory<HonestMarketContext>
{
    public HonestMarketContext CreateDbContext(string[] args)
    {
        var connection = Environment.GetEnvironmentVariable("HONESTMARKET_DATABASE") ?? string.Empty;
        var optionsBuilder = new DbContextOptionsBuilder<HonestMarketContext>();

        optionsBuilder.UseSqlServer(connection)
                      .EnableSensitiveDataLogging(false)
                      .EnableDetailedErrors(false);

        return new HonestMarketContext(optionsBuilder.Options);
    }
}
