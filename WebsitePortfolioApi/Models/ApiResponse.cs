
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

// Generic ApiResponse for typed responses
public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string Message { get; set; } = string.Empty;
    public int StatusCode { get; set; }

    // Constructor for successful responses
    public ApiResponse(T data, string message = "Success", int statusCode = 200)
    {
        Success = true;
        Data = data;
        Message = message;
        StatusCode = statusCode;
    }

    // Constructor for error responses
    public ApiResponse(string message, int statusCode = 400)
    {
        Success = false;
        Data = default(T);
        Message = message;
        StatusCode = statusCode;
    }

    // Full constructor
    public ApiResponse(bool success, T? data, string message, int statusCode)
    {
        Success = success;
        Data = data;
        Message = message;
        StatusCode = statusCode;
    }

    // Empty constructor
    public ApiResponse() { }

    // Static factory methods for consistency
    public static ApiResponse<T> SuccessResponse(T data, string message = "Success", int statusCode = 200)
    {
        return new ApiResponse<T>(true, data, message, statusCode);
    }

    public static ApiResponse<T> ErrorResponse(string message, int statusCode = 400)
    {
        return new ApiResponse<T>(false, default(T), message, statusCode);
    }

    // Additional helper methods
    public static ApiResponse<T> NotFound(string message = "Resource not found")
    {
        return new ApiResponse<T>(false, default(T), message, 404);
    }

    public static ApiResponse<T> BadRequest(string message = "Bad request")
    {
        return new ApiResponse<T>(false, default(T), message, 400);
    }

    public static ApiResponse<T> Unauthorized(string message = "Unauthorized")
    {
        return new ApiResponse<T>(false, default(T), message, 401);
    }

    public static ApiResponse<T> Forbidden(string message = "Forbidden")
    {
        return new ApiResponse<T>(false, default(T), message, 403);
    }

    public static ApiResponse<T> Conflict(string message = "Conflict")
    {
        return new ApiResponse<T>(false, default(T), message, 409);
    }

    public static ApiResponse<T> InternalServerError(string message = "Internal server error")
    {
        return new ApiResponse<T>(false, default(T), message, 500);
    }

    public static ApiResponse<T> Created(T data, string message = "Created successfully")
    {
        return new ApiResponse<T>(true, data, message, 201);
    }

    public static ApiResponse<T> NoContent(string message = "No content")
    {
        return new ApiResponse<T>(true, default(T), message, 204);
    }
}

// Non-generic version for responses without specific data type
public class ApiResponse
{
    public bool Success { get; set; }
    public object? Data { get; set; }
    public string Message { get; set; } = string.Empty;
    public int StatusCode { get; set; }

    public ApiResponse(bool success, object? data, string message, int statusCode)
    {
        Success = success;
        Data = data;
        Message = message;
        StatusCode = statusCode;
    }

    public ApiResponse() { }

    // Static methods for common responses
    public static ApiResponse SuccessResponse(object? data = null, string message = "Success", int statusCode = 200)
    {
        return new ApiResponse(true, data, message, statusCode);
    }

    public static ApiResponse ErrorResponse(string message, int statusCode = 400, object? data = null)
    {
        return new ApiResponse(false, data, message, statusCode);
    }

    public static ApiResponse NotFound(string message = "Resource not found", object? data = null)
    {
        return new ApiResponse(false, data, message, 404);
    }

    public static ApiResponse BadRequest(string message = "Bad request", object? data = null)
    {
        return new ApiResponse(false, data, message, 400);
    }

    public static ApiResponse Unauthorized(string message = "Unauthorized", object? data = null)
    {
        return new ApiResponse(false, data, message, 401);
    }

    public static ApiResponse Forbidden(string message = "Forbidden", object? data = null)
    {
        return new ApiResponse(false, data, message, 403);
    }

    public static ApiResponse Conflict(string message = "Conflict", object? data = null)
    {
        return new ApiResponse(false, data, message, 409);
    }

    public static ApiResponse InternalServerError(string message = "Internal server error", object? data = null)
    {
        return new ApiResponse(false, data, message, 500);
    }

    public static ApiResponse Created(object? data = null, string message = "Created successfully")
    {
        return new ApiResponse(true, data, message, 201);
    }

    public static ApiResponse NoContent(string message = "No content")
    {
        return new ApiResponse(true, null, message, 204);
    }
}

// Extension methods for cleaner controller usage
public static class ApiResponseExtensions
{
    public static IActionResult ToActionResult<T>(this ApiResponse<T> response)
    {
        return new ObjectResult(response)
        {
            StatusCode = response.StatusCode
        };
    }

    public static IActionResult ToActionResult(this ApiResponse response)
    {
        return new ObjectResult(response)
        {
            StatusCode = response.StatusCode
        };
    }
}