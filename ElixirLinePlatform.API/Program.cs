using ElixirLinePlatform.API.Shared.Domain.Repositories;
using ElixirLinePlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



//===================================Add services to the container=====================================
builder.Services.AddControllers();
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString == null)
{
    throw new InvalidOperationException("Connection string not found.");
}


builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {

        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
    else if (builder.Environment.IsProduction())
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
    }
});
//======================================================================================================

//======== Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle ========
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());
//======================================================================================================

// Dependency Injection

//===================================== Shared Bounded Context ====================================
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//=================================== END Shared Bounded Context ==================================







//===================================== 1. Bounded Context ================================


//===================================== Bounded Context ===============================









var app = builder.Build();


//==================== Verify if the database exists and create it if it doesn't ===================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();
}
//===============================================================================================


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