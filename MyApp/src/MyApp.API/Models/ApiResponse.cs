namespace MyApp.API.Models;

public class ApiResponse
{
    public bool Success { get; set; }

    public string? Message { get; set; }

    public object? Data { get; set; }

    public List<string>? Errors { get; set; }

    public ApiResponse(bool success = false, string? message = null, object? data = null, List<string>? errors = null)
    {
        Success = success;
        Message = message;
        Data = data;
        Errors = errors ?? new List<string>();
    }

    public static ApiResponse Ok(object? data = null, string? message = null) =>
        new ApiResponse(true, message, data);

    public static ApiResponse Failure(string? message, List<string>? errors = null) =>
        new ApiResponse(message : message, errors: errors);
}