using BlazorQuickGridApp.Server.Services;  // Import the service
using Microsoft.Extensions.DependencyInjection;

public class Setup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Add CORS policy
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", builder =>
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
        });

        services.AddControllers(); // Add MVC controllers to the DI container
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Use CORS policy
        app.UseCors("AllowAllOrigins");

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers(); // Map the controllers to API endpoints
        });
    }
}
