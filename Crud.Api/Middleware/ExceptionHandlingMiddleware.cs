using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mail;
using System.Security.Authentication;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Crude.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
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
                var statusCode = GetStatusCode(ex);
                context.Response.ContentType = "application/json";
                var errorResponse = new { statusCode ,  error = ex.Message };
                var json = JsonConvert.SerializeObject(errorResponse);
                await context.Response.WriteAsync(json);
            }
           
        }
        public int GetStatusCode(Exception exception)
        {

            switch (exception)
            {
                case ArgumentNullException ex:
                    return 400;
                    break;
                case InvalidOperationException ex:
                    return 400;
                    break;
                case KeyNotFoundException ex:
                    return 404;
                    break;
                default:
                    return 500;
                    break;
            }
           
          
        }
    }
}
