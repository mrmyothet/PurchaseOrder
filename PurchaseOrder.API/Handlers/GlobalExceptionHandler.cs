using Microsoft.AspNetCore.Diagnostics;

namespace PurchaseOrder.API.Handlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            Result<object> result = Result<object>.Failure(exception.Message);
            httpContext.Response.StatusCode = 200;

            await httpContext.Response.WriteAsJsonAsync(result, cancellationToken: cancellationToken);

            return true;
        }
    }
}
