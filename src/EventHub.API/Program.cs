using EventHub.Api.Extensions;
using EventHub.Infrastructure.Extensions;
using Serilog;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

// Add controllers
builder.Services.AddControllers();

// Add Application Services (EventService, ParticipantService, RegistrationService)
builder.Services.AddApiServices();

// Add Infrastructure (DbContext, Repositories)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddInfrastructure(connectionString);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EventHub API",
        Version = "v1",
        Description = "Event scheduling and registration API."
    });
});

var app = builder.Build();

// Serilog request logging
app.UseSerilogRequestLogging();

// Developer swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware (to add later)

app.UseApiExceptionMiddleware();
app.UseHttpsRedirection();
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();
