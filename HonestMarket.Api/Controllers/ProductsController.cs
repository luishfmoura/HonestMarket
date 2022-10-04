using HonestMarket.Api.Middlewares;
using HonestMarket.Application.DTO;
using HonestMarket.Application.Helpers;
using HonestMarket.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HonestMarket.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IApplicationServiceProduct _applicationService;
    private readonly string _entityName = "Produto";

    public ProductsController(IApplicationServiceProduct applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpGet]
    public IActionResult Get() => new HonestMarketResult(_applicationService.Get());

    [HttpGet]
    [Route("{guid}")]
    public IActionResult Get(string guid) => new HonestMarketResult(_applicationService.Get(guid));

    [HttpGet]
    [Route("{id}")]
    public IActionResult Get(int id) => new HonestMarketResult(_applicationService.Get(id));

    [HttpPost]
    public IActionResult Post([FromBody]ProductDto model)
    {
        bool data = _applicationService.Add(model);
        var message = data ? new ResponseMessages(_entityName).CREATED : ResponseMessages.NOTCREATED;
        return new HonestMarketResult(data, message);
    }

    [HttpPut]
    public IActionResult PutProduct(ProductDto model)
    {
        bool data = _applicationService.Update(model);
        var message = data ? new ResponseMessages(_entityName).UPDATED : ResponseMessages.NOTUPDATED;
        return new HonestMarketResult(data, message);
    }

    [HttpDelete]
    [Route("{guid}")]
    public IActionResult RemoveProduct(string guid)
    {
        bool data = _applicationService.Remove(guid);
        var message = data ? new ResponseMessages(_entityName).REMOVED : ResponseMessages.NOTREMOVED;
        return new HonestMarketResult(data, message);
    }
}