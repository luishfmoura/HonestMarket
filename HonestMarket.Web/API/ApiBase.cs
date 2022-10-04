using Newtonsoft.Json;
using RestSharp;

namespace HonestMarket.Web.API;

public abstract class ApiBase
{
    private readonly IConfiguration _configuration;

    protected string? Host { get; set; } = null;
    private string? Url { get; set; } = null;
    private RestClient Client { get; set; }
    private RestRequest Request { get; set; }

    public ApiBase(IConfiguration configuration, HttpContext context, string uri, Method method = Method.Get, string content = "application/json")
    {
        _configuration = configuration;

        this.Host = _configuration![this.GetType().Name];
        this.Request = new RestRequest()
        {
            Method = method,
            Timeout = int.MaxValue
        };
        this.Request.AddHeader("cache-control", "no-cache");
        this.Request.AddHeader("Content-Type", content);
        this.Request.AddHeader("Connection", "keep-alive");

        this.Url = this.Host + uri;
        this.Client = new RestClient(this.Url);
    }

    public ResponseApi<T> Execute<T>(object? data = null)
    {
        var model = new ResponseApi<T>();

        if (data != null && this.Request.Method == Method.Post ||
                            this.Request.Method == Method.Put)
        {
            this.Request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
        }

        var response = this.Client.Execute(this.Request);

        model = !string.IsNullOrEmpty(response!.Content) ? JsonConvert.DeserializeObject<ResponseApi<T>>(response!.Content!) : null;
        model!.Code = response.StatusCode;

        return model;
    }
}

