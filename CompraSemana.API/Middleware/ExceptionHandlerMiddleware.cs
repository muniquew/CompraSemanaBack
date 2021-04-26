using CompraSemana.Core.Util.Exception;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace CompraSemana.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro registrado via middleware global - {ex}", ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var type = ex.GetType();
            int status;
            string trace = string.Empty;

            if (type == typeof(DataRepoException))
            {
                status = ((int)HttpStatusCode.BadRequest);
            }
            else if (type == typeof(ServiceException))
            {
                status = ((int)HttpStatusCode.NotFound);
            }
            else
            {
                status = ((int)HttpStatusCode.InternalServerError);
                trace = ex.StackTrace;
            }

            context.Response.ContentType = "application/json";

            var problemDetail = new
            {
                statusCode = (int)status,
                message = ex.Message,
                trace = _env.EnvironmentName == "Development" ? trace : string.Empty
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(problemDetail));
        }
    }
}
