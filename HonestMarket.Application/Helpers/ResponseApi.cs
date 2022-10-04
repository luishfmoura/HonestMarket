namespace HonestMarket.Application.Helpers;

public class ResponseApi
{
    public bool Success { get; set; }
    public object? Data { get; set; } = default;
    public string? Message { get; set; } = null;

    public ResponseApi(bool success, string? message = null, object? data = null)
    {
        Success = success;
        Data = data;
        Message = message;
    }
}
