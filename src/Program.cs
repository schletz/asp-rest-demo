
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using System;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine("Version: 2024-03-15 09:19");
Console.WriteLine($"Running in {builder.Environment.EnvironmentName}");

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// docker run -d -p 5432:5432 -e POSTGRES_PASSWORD=demo -e POSTGRES_USER=demo --name postgres  postgres
builder.Services.AddDbContext<DemoContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

Console.WriteLine($"Connection string: {app.Configuration.GetConnectionString("DefaultConnection")}");
using (var scope = app.Services.CreateScope())
{
    using var context = scope.ServiceProvider.GetRequiredService<DemoContext>();
    if (app.Environment.IsDevelopment())
        context.Database.EnsureDeleted();
    if (context.Database.EnsureCreated())
        await context.Seed();
}
app.MapControllers();
app.MapRazorPages();
app.UseStaticFiles();
app.Run();
