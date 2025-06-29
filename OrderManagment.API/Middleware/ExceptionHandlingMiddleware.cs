namespace OrderManagment.API.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context, IHostEnvironment env)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        (int statusCode, object response) = exception switch
        {
            KeyNotFoundException keyNotFoundException =>
                (StatusCodes.Status404NotFound, new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = keyNotFoundException.Message
                }),
            InvalidOperationException invalidOperationException =>
                (StatusCodes.Status500InternalServerError, new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = invalidOperationException.Message
                }),
            _ => 
                (StatusCodes.Status500InternalServerError, new
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "An internal server error has occurred.",
                })
        };

        context.Response.StatusCode = statusCode;
        return context.Response.WriteAsJsonAsync(response);
    }
}