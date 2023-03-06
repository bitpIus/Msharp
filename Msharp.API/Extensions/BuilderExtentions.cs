namespace Msharp.Api.Extensions;

public static class BuilderExtentions
{
    public static void BuildConfiguration(this WebApplicationBuilder builder)
    {
        builder.WebHost.ConfigureLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddConsole();
        });
    }

}