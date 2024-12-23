using System.Net;

namespace Infrastructure.ApiResponse;

public class Response<T>
{
    public int StatusCode { get; set; }
    public T? Data { get; set; }
    public string Message { get; set; }
    
    public Response(T data)
    {
        StatusCode = 200;
        Message = "message";
        Data = data;
    }

    public Response(HttpStatusCode statusCode, string message)
    {
        StatusCode = (int)statusCode;
        Data = default;
        Message = message;
    }
}