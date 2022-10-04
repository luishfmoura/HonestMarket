using RestSharp;

namespace HonestMarket.Web.API;

public class HonestMarketApi : ApiBase
{
    public HonestMarketApi(IConfiguration config, HttpContext context, string uri, Method method = Method.Get, string content = "application/json") : base(config, context, uri, method, content) { }
}
