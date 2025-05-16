using ElixirLinePlatform.API.Modules.FieldWorkers.Services;
using ElixirLinePlatform.API.Modules.FieldWorkers.Entities;
using ElixirLinePlatform.API.Modules.FieldWorkers;
using ElixirLinePlatform.API.Shared.Domain.Repositories;
using ElixirLinePlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ==================================== Configuración de servicios ====================================
builder.Services.AddControllers();
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// 🔑 Leer cadena de conexión desde appsettings.json
/*var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
*/
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("FieldWorkersDB")
           .LogTo(Console.WriteLine, LogLevel.Information)
           .EnableSensitiveDataLogging()
           .EnableDetailedErrors();
});


// ===============================================================================================

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// Inyección de dependencias
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<FieldWorkerService>();

var app = builder.Build();

// ====================== Crear la base de datos y hacer seed si es necesario =======================
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // ⚠️ Ya no se usa EnsureCreated con MySQL. Se verifica migraciones pendientes (si aplica).
    if (!db.FieldWorkers.Any())
    {
        db.FieldWorkers.AddRange(
            new FieldWorker
            {
                FullName = "Marco Berrati",
                DNI = "12345678",
                Email = "marco@campo.pe",
                Phone = "987654321",
                Position = "Podador",
                WorkLocation = "Sector A"
            },
            new FieldWorker
            {
                FullName = "Lucía Huamán",
                DNI = "87654321",
                Email = "lucia@campo.pe",
                Phone = "912345678",
                Position = "Riego",
                WorkLocation = "Sector B"
            }
        );

        db.SaveChanges();
    }
}
// ===============================================================================================

// Configuración del pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
