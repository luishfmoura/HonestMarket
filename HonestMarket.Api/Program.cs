using HonestMarket.Api.Middlewares;
using HonestMarket.CrossCutting.IOC;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

ConfigurationIOC.LoadDatabase(builder.Services);
ConfigurationIOC.LoadServices(builder.Services, builder.Configuration);
ConfigurationIOC.LoadMapper(builder.Services);
ConfigurationIOC.LoadSwagger(builder.Services);

builder.Services.AddControllers()
                .AddJsonOptions(option => option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

var url = app.Environment.IsDevelopment() ? null : Environment.GetEnvironmentVariable("HOST_PRD");

app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin());

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<HandlerExceptionApi>();

app.MapControllers();

app.Run(url);
