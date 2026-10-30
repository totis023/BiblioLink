using Microsoft.EntityFrameworkCore;
using BiblioLink.Interfaces;
using BiblioLink.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers(); //registra los controladores
builder.Services.AddOpenApi();
builder.Services.AddDbContext<BibliotecaContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("BibliotecaDb")));
builder.Services.AddScoped<ILibroService, LibroService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers(); //contecta rutas con controladores

app.Run();