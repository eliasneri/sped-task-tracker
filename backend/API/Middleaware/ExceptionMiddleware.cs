using System.Net;
using TaskTracker.Domain.Exceptions;

namespace DefaultNamespace;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DomainException ex)
        {
            context.Response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();
            await context.Response.WriteAsJsonAsync(new
            {
                error = ex.Message
            });
        }
        catch (Exception)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError.GetHashCode();
            await context.Response.WriteAsJsonAsync(new
            {
                error = "Internal Error!"
            });
        }
    }
}