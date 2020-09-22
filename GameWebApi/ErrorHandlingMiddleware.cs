using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class ErrorHandlerMiddleware
{

    private readonly RequestDelegate _next;
    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);

        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}