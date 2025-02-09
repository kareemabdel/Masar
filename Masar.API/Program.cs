using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Masar.API.IoC;
using Masar.Application.IoC;
using Masar.Infrastructure.ApplicationContext;
using Masar.Infrastructure.IoC;
using Masar.Application.Interfaces;
using Masar.Infrastructure.Services;
using Masar.API.Middleware.ExceptionHandling;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddHttpContextAccessor();  
builder.Services.AddAPIServices(builder.Configuration);
await builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.ConfigureLoggerServices();
builder.Services.ConfiguareLocalizationServices();
builder.Services.AddAuthSrvices(builder.Configuration);
builder.Services.AddMemoryCache();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379"; // Redis server connection
});
var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
// Configure the HTTP request pipeline.

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
        if (context.Database.IsSqlServer())
            context.Database.Migrate();
    }
    catch (Exception ex)
    {
        //Log.Fatal(ex, "Application start-up failed");
    }
}

app.UseHttpsRedirection();
app.UseCors("_myAllowedOrigins");
app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
