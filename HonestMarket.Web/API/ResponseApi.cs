using System.Net;

namespace HonestMarket.Web.API;

public class ResponseApi<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; } = default;
    public string? Message { get; set; } = null;
    public HttpStatusCode Code { get; set; }
}
