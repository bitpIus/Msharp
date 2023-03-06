using Msharp.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.BuildConfiguration();

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, builder.Environment);

app.Run();
