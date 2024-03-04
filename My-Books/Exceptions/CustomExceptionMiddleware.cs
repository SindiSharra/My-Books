using My_Books.Controllers;
using My_Books.Data.ViewModels;
using System.Net;

namespace My_Books.Exceptions
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvkeAsync(HttpContext httpContext)
        {
            try
            {
                _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, object ex)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            var response = new ErrorVM()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = "Custom Error Handling by my middleware",
                Path = "path-path"
            };

            return httpContext.Response.WriteAsync(response.ToString());
        }
    }
}
