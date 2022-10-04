using HonestMarket.Application.Exceptions;
using HonestMarket.Application.Helpers;
using HonestMarket.Domain.Constants;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace HonestMarket.Api.Middlewares;

public class HandlerExceptionApi
{
    private readonly RequestDelegate _next;
    private readonly ILogger<HandlerExceptionApi> _logger;

    public HandlerExceptionApi(RequestDelegate next, ILogger<HandlerExceptionApi> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var response = context.Response;

        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            var r = new ResponseApi(false, e.Message);

            response.ContentType = "application/json; charset=utf-8";
            response.StatusCode = e switch
            {
                HonestMarketNocontentException => (int)HttpStatusCode.NotFound,
                HonestMarketNotFoundException => (int)HttpStatusCode.NotFound,
                HonestMarketUnauthorizedException => (int)HttpStatusCode.Unauthorized,
                HonestMarketExpiredUserException => (int)HttpStatusCode.Locked,
                HonestMarketInternalServerErrorException => (int)HttpStatusCode.InternalServerError,
                HonestMarketException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

            if (response.StatusCode == (int)HttpStatusCode.InternalServerError)
            {
                _logger.LogError(e.Message + e.StackTrace);
                r = new ResponseApi(false, ExceptionMessages.INTERNAL_SERVER_ERROR);
            }

            var json = JsonConvert.SerializeObject(r);
            var b = Encoding.ASCII.GetBytes(json);

            await response.Body.WriteAsync(b).AsTask();
            await response.StartAsync();
        }
    }
}
