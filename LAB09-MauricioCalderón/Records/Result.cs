namespace LAB08_MauricioCalderón.Records;

public class Result<T>
{
    public bool Success { get; init; }
    public T? Data { get; init; }
    public string? Message { get; init; }
    public int StatusCode { get; init; }

    public static Result<T> Ok(T data) => new()
    {
        Success = true,
        Data = data,
        StatusCode = 200
    };

    public static Result<T> Created(T data) => new()
    {
        Success = true,
        Data = data,
        StatusCode = 201
    };

    public static Result<T> Failure(string message, int statusCode = 400) => new()
    {
        Success = false,
        Message = message,
        StatusCode = statusCode
    };
}