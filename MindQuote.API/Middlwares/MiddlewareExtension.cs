namespace MindQuote.API.Middlwares;

public static class MiddlewareExtension
{
    public static IApplicationBuilder UseCustomeExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}