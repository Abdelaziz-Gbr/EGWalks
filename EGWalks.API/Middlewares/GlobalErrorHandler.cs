using System.Net;

namespace EGWalks.API.Middlewares
{
    public class GlobalErrorHandler
    {
        private readonly ILogger<GlobalErrorHandler> logger;
        private readonly RequestDelegate requestDelegate;

        public GlobalErrorHandler(ILogger<GlobalErrorHandler> logger, RequestDelegate requestDelegate)
        {
            this.logger = logger;
            this.requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                var errorID = Guid.NewGuid();
                // log 
                logger.LogError(ex, $"{errorID} : {ex.Message}");

                // return custome error Response
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var msg = new { Id = errorID, errorMessage = "something went wrong, please contact us and provide the error id." };

                await httpContext.Response.WriteAsJsonAsync(msg);
            }
        }

    }
}