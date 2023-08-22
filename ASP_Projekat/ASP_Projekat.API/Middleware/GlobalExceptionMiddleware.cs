using ASP_Projekat.Application.Exceptions;
using ASP_Projekat.Application.Logging;
using FluentValidation;

namespace ASP_Projekat.API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private IExceptionLogger _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, IExceptionLogger logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = 422;

                var errors = ex.Errors.Select(x => new
                {
                    x.ErrorMessage,
                    x.PropertyName
                });

                await context.Response.WriteAsJsonAsync(errors);
            }

            catch (UnauthorizedUserUseCaseException ex)
            {
                context.Response.StatusCode = 401;
            }
            catch (UnauthorizedAccessException ex)
            {
                context.Response.StatusCode = 401;
            }
            catch (EntityNotFoundException)
            {
                context.Response.StatusCode = 404;
            }
            catch (System.Exception ex)
            {
                Guid errorId = Guid.NewGuid();
                AppError error = new AppError
                {
                    Exception = ex,
                    ErrorId = errorId,
                    Username = "test"
                };

                _logger.Log(error);

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var responseBody = new
                {

                    message = $"There was an error, please contact support with this error code: {errorId}."
                };

                await context.Response.WriteAsJsonAsync(ex.Message.ToString());
            }
        }
    }
}
