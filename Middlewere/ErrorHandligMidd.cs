﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;



namespace Premier.Middlewere
{
    public class ErrorHandlingMidd : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMidd> _logger;

        public ErrorHandlingMidd(ILogger<ErrorHandlingMidd> logger)
        {
            this._logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            //catch (NotFoundException notFoundException)
            //{
            //    context.Response.StatusCode = 404;
            //    await context.Response.WriteAsync(notFoundException.Message);
            //}
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong, server error");
            }
        }
        //public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        //{
        //    try
        //    {
        //        await next.Invoke(context);
        //    }
        //catch (ForbidException forbidException)
        //{
        //    context.Response.StatusCode = 403;
        //}
        //catch (BadRequestException badRequestException)
        //{
        //    context.Response.StatusCode = 400;
        //    await context.Response.WriteAsync(badRequestException.Message);
        //}
        //catch (NotFoundException notFoundException)
        //{
        //    context.Response.StatusCode = 404;
        //    await context.Response.WriteAsync(notFoundException.Message);
        //}
        //catch (Exception e)
        //{
        //    _logger.LogError(e, e.Message);

        //    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //    await context.Response.WriteAsync("Something went wrong");
        //}

    }
}