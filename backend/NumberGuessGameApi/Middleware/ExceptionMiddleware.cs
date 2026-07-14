using System.Net;
using System.Text.Json;

namespace NumberGuessGameApi.Middleware;

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
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = ex.Message switch
            {
                "El correo electrónico ya está registrado." => (int)HttpStatusCode.Conflict,
                "Correo o contraseña incorrectos." => (int)HttpStatusCode.Unauthorized,
                "El jugador no existe." => (int)HttpStatusCode.NotFound,
                "La partida no existe." => (int)HttpStatusCode.NotFound,
                "La partida no existe o no pertenece al jugador." => (int)HttpStatusCode.NotFound,
                "La partida ya finalizó." => (int)HttpStatusCode.BadRequest,

                _ => (int)HttpStatusCode.InternalServerError
            };

            var response = new
            {
                message = ex.Message
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }
}