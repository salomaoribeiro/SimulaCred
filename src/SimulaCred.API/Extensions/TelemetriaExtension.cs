namespace SimulaCred.API.Extensions;

public static class TelemetriaExtension
{
    public static IApplicationBuilder UseTelemetria(this IApplicationBuilder app)
    {
        return app;
    }
}