using System.Reflection;
using Microsoft.OpenApi.Models;

namespace TaskTracker.API.Configurations;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "TaskTracker API",
                Version = "v1",
                Description = "API para gerenciamento de tarefas — Teste Técnico",
                Contact = new OpenApiContact
                {
                    Name = "Elias A. Neri",
                    Email = "eliasneri@hotmail.com"
                }
            });

            // Habilita os comentários XML nos endpoints (summary dos controllers)
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath))
                options.IncludeXmlComments(xmlPath);
        });

        return services;
    }

    public static WebApplication UseSwaggerConfiguration(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskTracker API v1");
            options.RoutePrefix = "swagger";
            options.DocumentTitle = "TaskTracker API";
        });

        return app;
    }
}