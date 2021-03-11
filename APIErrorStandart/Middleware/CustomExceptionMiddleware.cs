using Business.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace APIErrorStandart.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (HttpStatusCodeException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception exceptionObj)
            {
                await HandleExceptionAsync(context, exceptionObj);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, HttpStatusCodeException exception)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            return SetResponseStatusAsync(context.Response, exception);
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var ex = new HttpStatusCodeException(HttpStatusCode.InternalServerError, exception);
            return SetResponseStatusAsync(context.Response, ex);
        }


        public static Task SetResponseStatusAsync(HttpResponse httpResponse, HttpStatusCodeException response)
        {
            httpResponse.ContentType = "application/json; charset=utf-8";
            httpResponse.StatusCode = response.ResponseModel.Status ?? 500;
            return httpResponse.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response.ResponseModel));
        }

    }
}
