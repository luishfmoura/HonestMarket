using HonestMarket.Web.API;
using HonestMarket.Web.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace HonestMarket.Web.Controllers;

public class ProductsController : Controller
{
    private readonly IConfiguration _config;

    public ProductsController(IConfiguration config)
    {
        _config = config;
    }

    [HttpGet]
    public IActionResult Index() => View();

    [HttpGet]
    public IActionResult GetProducts()
    {
        var response = new HonestMarketApi(_config, HttpContext, $"Products").Execute<List<ProductResponse>>();
        return Json(response);
    }

    [HttpGet]
    public IActionResult GetProduct(string guid)
    {
        var response = new HonestMarketApi(_config, HttpContext, $"Products/{guid}").Execute<ProductResponse>();
        return Json(response);
    }

    [HttpPost]
    public IActionResult PostProduct(ProductResponse model)
    {
        var response = new HonestMarketApi(_config, HttpContext, $"Products/{model}", Method.Post).Execute<bool>();
        return Json(response);
    }

    [HttpPost]
    public IActionResult PutProduct(ProductResponse model)
    {
        var response = new HonestMarketApi(_config, HttpContext, $"Products/{model}", Method.Put).Execute<bool>();
        return Json(response);
    }

    [HttpGet]
    public IActionResult RemoveProduct(string guid)
    {
        var response = new HonestMarketApi(_config, HttpContext, $"Products/{guid}", Method.Delete).Execute<bool>();
        return Json(response);
    }
}