using HonestMarket.Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HonestMarket.Api.Middlewares;

public class HonestMarketResult : IActionResult
{
    private readonly ResponseApi _response;

    public HonestMarketResult(object? data, string? message = null)
    {
        _response = new ResponseApi(true, message, data);
    }

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var objectResult = new ObjectResult(_response)
        {
            StatusCode = context.HttpContext.Request.Method == "POST" ? (int)HttpStatusCode.Created : (int)HttpStatusCode.OK
        };

        await objectResult.ExecuteResultAsync(context);
    }
}
