using Microsoft.EntityFrameworkCore;
using Backend.Mappers;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using FizzBuzzDatabase.Data;
using FizzBuzzDatabase.Interfaces.IRepositories;
using FizzBuzzDatabase.Interfaces.IServices;
using FizzBuzzDatabase.Mappers;
using FizzBuzzDatabase.Server.Repositories;
using FizzBuzzDatabase.Services;

var builder = WebApplication.CreateBuilder(args);

// =============================================
// 1. Database Configuration
// =============================================
builder.Services.AddDbContext<GameDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// =============================================
// 2. Dependency Injection Setup
// =============================================
// Add CORS policy (place this right before AutoMapper configuration)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:3000") // Frontend URL
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials()); // Add if using cookies/auth
});

// AutoMapper
builder.Services.AddAutoMapper(
    typeof(GameMapper),
    typeof(GameRuleMapper),
    typeof(GameSessionMapper),
    typeof(PlayerMapper)
);

// Repositories
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGameRuleRepository, GameRuleRepository>();
builder.Services.AddScoped<IGameSessionRepository, GameSessionRepository>();

// Services
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGameRuleService, GameRuleService>();
builder.Services.AddScoped<IGameSessionService, GameSessionService>();

// =============================================
// 3. API Behavior & JSON Configuration
// =============================================
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = false;
});

// =============================================
// 4. Swagger/OpenAPI Customization
// =============================================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FizzBuzz Game API",
        Version = "v1",
        Description = "<b>API for custom FizzBuzz-like game</b><br>" +
                     "<br>Features:" +
                     "<ul>" +
                     "<li>Game session management</li>" +
                     "<li>Dynamic rule configuration</li>" +
                     "<li>Real-time answer validation</li>" +
                     "</ul>",
        Contact = new OpenApiContact
        {
            Name = "Daniel Do",
            Email = "duy.do503@outlook.com",
            Url = new Uri("https://github.com/anhduy0220")
        }
    });

    // Enable XML comments
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }

    // Add bearer token support (if using authentication)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
});

// =============================================
// 5. Build Application
// =============================================
var app = builder.Build();

// =============================================
// 6. Middleware Pipeline
// =============================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FizzBuzz API v1");
        c.DocumentTitle = "FizzBuzz API Explorer";
        c.RoutePrefix = "swagger"; // Access via /api-docs
        c.InjectStylesheet("/swagger-ui/custom.css"); // For custom styling
    });
}

// Add CORS middleware (must come before UseHttpsRedirection and MapControllers)
app.UseCors("AllowFrontend");

// Automatic redirect to Swagger
app.Use(async (context, next) =>
{
    if (context.Request.Path.Value == "/")
    {
        context.Response.Redirect("/swagger"); // Changed to match RoutePrefix
        return;
    }
    await next();
});

// Optional: Serve custom Swagger CSS
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// =============================================
// 7. Database Initialization
// =============================================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<GameDB>();
        context.Database.Migrate();
        // Seed data here if needed
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Database migration failed");
    }
}

app.Run();