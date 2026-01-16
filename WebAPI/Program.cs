using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Mapper;
using System.Text.Json.Serialization;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();


builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServices(builder.Configuration);
builder.Services.ConfigureIdentity(builder.Configuration);
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureMediatR();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<Services.Mapper.MappingProfile>();
});


var app = builder.Build();
app.ConfigureExceptionHandler();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


// --- OTOMATÝK MIGRATION MÜHÜRÜ BAÞLANGIÇ ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<Repository.EFCore.RepositoryContext>(); // Senin context ismin
        await context.Database.MigrateAsync();
        // Burasý çalýþtýðýnda hem DB oluþur hem de senin Config dosyalarýndaki HasData verileri içeri akar!
    }
    catch (Exception ex)
    {
        // Loglama yapabilirsin, þimdilik boþ kalsýn
    }
}
// --- OTOMATÝK MIGRATION MÜHÜRÜ BÝTÝÞ ---

app.Run();
