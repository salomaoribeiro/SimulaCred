using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace SimulaCred.API.Middleware;

public class GlobalErrorHandlerMiddleware : IMiddleware
{
    // private readonly RequestDelegate _next;
    private readonly ILogger<GlobalErrorHandlerMiddleware> _logger;
    
    public GlobalErrorHandlerMiddleware(ILogger<GlobalErrorHandlerMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ProblemDetails problema = new ProblemDetails()
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Erro interno no servidor",
                Type = "Erro interno no servidor",
                Detail = "Houve um erro interno"
            };
            string json = JsonSerializer.Serialize(problema);
            await context.Response.WriteAsync(json);
            context.Response.ContentType = "application/json";
        }
    }
}