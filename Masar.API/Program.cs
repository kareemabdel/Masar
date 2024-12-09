using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Masar.API.IoC;
using Masar.Application.IoC;
using Masar.Infrastructure.ApplicationContext;
using Masar.Infrastructure.IoC;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddHttpContextAccessor();  
builder.Services.AddAPIServices(builder.Configuration);
await builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.ConfigureLoggerServices();
builder.Services.ConfiguareLocalizationServices();
builder.Services.AddAuthSrvices(builder.Configuration);

var app = builder.Build();

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
