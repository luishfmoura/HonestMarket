using AutoMapper;
using HonestMarket.Application;
using HonestMarket.Application.DTO;
using HonestMarket.Application.Interfaces;
using HonestMarket.Domain.Core.Repositories;
using HonestMarket.Domain.Core.Services;
using HonestMarket.Domain.Entities;
using HonestMarket.Domain.Services;
using HonestMarket.Infra.Data.Context;
using HonestMarket.Infra.Data.Repositories;
using HonestMarket.Infra.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace HonestMarket.CrossCutting.IOC;

public static class ConfigurationIOC
{
    public static void LoadMapper(IServiceCollection services)
    {
        var autoMapper = new MapperConfiguration(config =>
        {
            config.CreateMap<Product, ProductDto>();
            config.CreateMap<ProductDto, Product>();
        });

        IMapper mapper = autoMapper.CreateMapper();

        services.TryAddSingleton(mapper);
    }

    public static void LoadServices(IServiceCollection services, IConfigurationBuilder config)
    {
        services.TryAddSingleton(config);

        services.AddScoped<IApplicationServiceProduct, ApplicationServiceProduct>();

        services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));

        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
    }

    public static void LoadDatabase(IServiceCollection services)
    {
        var connection = Environment.GetEnvironmentVariable("HONESTMARKET_DATABASE") ?? string.Empty;

        services.AddDbContext<HonestMarketContext>(options => options.UseSqlServer(connection)
                                                                 .EnableSensitiveDataLogging(false)
                                                                 .EnableDetailedErrors(false));

        using var context = services.BuildServiceProvider()
                                    .GetRequiredService<HonestMarketContext>();

        context.Database.Migrate();

        //context.SeedProduct();
    }

    public static void LoadSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(c => c.LoadOpenApiOptions());
    }

    private static void LoadOpenApiOptions(this SwaggerGenOptions options)
    {
        var contact = new OpenApiContact()
        {
            Name = "Luís Moura",
            Email = "luishfmoura@gmail.com",
            Url = new Uri("mailto:luishfmoura@gmail.com")
        };
        var license = new OpenApiLicense()
        {
            Name = "Fake Product",
            Url = new Uri("https://www.fakeProduct.com.br")
        };
        var info = new OpenApiInfo()
        {
            Version = "v1",
            Title = "Fake Product | Honest Market",
            Description = "Honest Market Application",
            TermsOfService = new Uri("https://www.fakeProduct.com.br"),
            Contact = contact,
            License = license
        };

        options.SwaggerDoc("v1", info);
    }
}