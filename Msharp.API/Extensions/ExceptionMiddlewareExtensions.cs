using Microsoft.AspNetCore.Diagnostics;
using Msharp.Domain.ErrorModel;

namespace Msharp.Api.Extensions;


public static class ExceptionHandlerExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (errorFeature != null)
                {
                    var logger = context.RequestServices.GetService(typeof(ILogger<Startup>)) as ILogger<Startup>;
                    logger.LogError(errorFeature.Error, errorFeature.Error.Message);


                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal Server Error."
                    }.ToString());
                }
            });
        });

        return app;
    }
}
