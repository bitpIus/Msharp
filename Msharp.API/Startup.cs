using Microsoft.AspNetCore.HttpOverrides;
using Msharp.Api.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class Startup
{
    public IConfiguration _configuration { get; }

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        
        services.AddLogging();
        services.AddAutoMapper(typeof(Startup));

        services.ConfigureCors();
        services.ConfigureSqlContext(_configuration);
        services.ConfigureRepositoryManager();

        services.AddSwaggerGen();
        services.AddEndpointsApiExplorer();

        services.AddControllers().AddNewtonsoftJson(options =>
        {
            // Use the default property (Pascal) casing
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });
    }

    public void Configure(WebApplication app, IWebHostEnvironment webHostEnvironment)
    {
        

        if (webHostEnvironment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            //app.UseGlobalExceptionHandler();
        }
        //app.UseGlobalExceptionHandler();

        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseCors("CorsPolicy");
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.All
        });

        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();

    }
}