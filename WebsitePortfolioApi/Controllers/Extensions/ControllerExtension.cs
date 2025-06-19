using Microsoft.AspNetCore.Mvc;

public static class ControllerExtensions
{
    public static IActionResult ApiOk<T>(this ControllerBase controller, T data, string message = "Success")
    {
        var response = new ApiResponse<T>(data, message, 200);
        return controller.Ok(response);
    }

    public static IActionResult ApiCreated<T>(this ControllerBase controller, T data, string message = "Created successfully")
    {
        var response = new ApiResponse<T>(data, message, 201);
        return controller.StatusCode(201, response);
    }

    public static IActionResult ApiBadRequest(this ControllerBase controller, string message = "Bad request")
    {
        var response = new ApiResponse<object>(message, 400);
        return controller.BadRequest(response);
    }

    public static IActionResult ApiNotFound(this ControllerBase controller, string message = "Not found")
    {
        var response = new ApiResponse<object>(message, 404);
        return controller.NotFound(response);
    }

    public static IActionResult ApiInternalServerError(this ControllerBase controller, string message = "Internal server error")
    {
        var response = new ApiResponse<object>(message, 500);
        return controller.StatusCode(500, response);
    }

    public static IActionResult ApiUnauthorized(this ControllerBase controller, string message = "Unauthorized")
    {
        var response = new ApiResponse<object>(message, 401);
        return controller.Unauthorized(response);
    }

    public static IActionResult ApiForbidden(this ControllerBase controller, string message = "Forbidden")
    {
        var response = new ApiResponse<object>(message, 403);
        return controller.StatusCode(403, response);
    }
}