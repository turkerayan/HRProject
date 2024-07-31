using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Errors.Model;

namespace IkProject.Application.Expections
{
    public class ExpectionMiddelware : IExceptionHandler
    {
        private readonly ILogger<ExpectionMiddelware> _logger;

        public ExpectionMiddelware(ILogger<ExpectionMiddelware> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, $"Exception occurred:{exception.Message}");

            var status = GetStatsusCode(exception);

            httpContext.Response.StatusCode = status;
            var problemDetails = new ProblemDetails();
            problemDetails.Status = status;
            if (exception.GetType() == typeof(ValidationException))
            {
                var errors = ((ValidationException)exception).Errors.Select(x => x.ErrorMessage).ToList();
                problemDetails.Title = string.Join(", ", errors);
            }
            else
                problemDetails.Title = $"{exception.Message}";


            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
        private static int GetStatsusCode(Exception exception) =>
           exception switch
           {
               BadRequestException => StatusCodes.Status400BadRequest,
               NotFoundException => StatusCodes.Status404NotFound,
               ValidationException => StatusCodes.Status422UnprocessableEntity,
               _ => StatusCodes.Status500InternalServerError
           };
    }
}
