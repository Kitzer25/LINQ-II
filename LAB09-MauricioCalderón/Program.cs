using LAB08_MauricioCalderón.Interfaces;
using LAB08_MauricioCalderón.Interfaces.IRepositories;
using LAB08_MauricioCalderón.Interfaces.IServices;
using LAB08_MauricioCalderón.Models;
using LAB08_MauricioCalderón.Repositories;
using LAB08_MauricioCalderón.Repositories.Entitys;
using LAB08_MauricioCalderón.Services.Entitys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
/*
 * dbContext
 */
builder.Services.AddDbContext<dbContextLINQ>(options =>
{
    var cStrings = config.GetConnectionString("DefaulConnections");

    options.UseMySql(
        cStrings,
        ServerVersion.AutoDetect(cStrings)
    );
});


/*
 * Json Web Token
 */



/*
 * Interfaz - Implementación 
 */

// -------> Repositories
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IDetallesOrdenRepository, DetallesOrdenRepository>();
builder.Services.AddScoped<IOrdenRepository, OrdenRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

// -------> Services
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IDetallesOrdenService, DetallesOrdenService>();
builder.Services.AddScoped<IOrdenService, OrdenService>();
builder.Services.AddScoped<IProductoService, ProductoService>();

// -------> UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


/*
 * AutoMapper
 */
builder.Services.AddAutoMapper(typeof(Program).Assembly);


/*
 * Swagger
 */
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
