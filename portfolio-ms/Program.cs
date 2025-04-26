using Microsoft.EntityFrameworkCore;
using portfolio_ms.Data;
using portfolio_ms.Endpoints;
using portfolio_ms.Handlers.Implementations;
using portfolio_ms.Handlers.Interfaces;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IProjectHandler, ProjectHandler>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options
        .WithTitle("Portfolio Management API")
        .WithTheme(ScalarTheme.Kepler);
});
app.MapEndpoints();
app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.Run();