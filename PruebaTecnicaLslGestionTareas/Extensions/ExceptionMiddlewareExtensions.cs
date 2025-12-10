using PruebaTecnicaLslGestionTareas.Middlewares;

namespace PruebaTecnicaLslGestionTareas.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalException(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
