using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Services;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------------------------
// Configure services (Dependency Injection container)
// ---------------------------------------------

// Add controller support (API endpoints)
builder.Services.AddControllers();

// Enable OpenAPI/Swagger for API documentation
// Learn more: https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register EF Core DbContext with SQL Server provider
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register application services (Scoped lifetime: one per request)
builder.Services.AddScoped<IVideoGameCharacterService, VideoGameCharacterService>();

var app = builder.Build();

// ---------------------------------------------
// Configure HTTP request pipeline (Middleware)
// ---------------------------------------------

if (app.Environment.IsDevelopment())
{
    // Map OpenAPI endpoints for API exploration in development
    app.MapOpenApi();

    // Map Scalar API reference (interactive API docs)
    app.MapScalarApiReference();
}

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Enable authorization middleware (requires [Authorize] attributes)
app.UseAuthorization();

// Global exception handler middleware
app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.ContentType = "application/json";

        var error = context.Features.Get<IExceptionHandlerFeature>();
        if (error is null) return;

        // Map exception types to HTTP status codes
        context.Response.StatusCode = error.Error switch
        {
            ArgumentNullException => StatusCodes.Status400BadRequest, // Bad Request
            KeyNotFoundException => StatusCodes.Status404NotFound,    // Not Found
            InvalidOperationException => StatusCodes.Status409Conflict, // Conflict
            _ => StatusCodes.Status500InternalServerError             // Internal Server Error
        };

        // Return standardized error response as JSON
        await context.Response.WriteAsJsonAsync(new
        {
            StatusCode = context.Response.StatusCode,
            Message = error.Error.Message
        });
    });
});

// Map controller endpoints (attribute routing)
app.MapControllers();

// Run the application
app.Run();
