using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Добавьте services к контейнеру
builder.Services.AddControllers();

// Добавьте IConfiguration
builder.Configuration.AddJsonFile("appsettings.json"); // Уточните путь к вашему файлу конфигурации

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
