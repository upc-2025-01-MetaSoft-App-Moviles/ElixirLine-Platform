using ElixirLinePlatform.API.DigitalFieldLog.Application.Internal.CommandServices;
using ElixirLinePlatform.API.DigitalFieldLog.Application.Internal.QueryServices;
using ElixirLinePlatform.API.DigitalFieldLog.Domain.Repositories;
using ElixirLinePlatform.API.DigitalFieldLog.Domain.Services;
using ElixirLinePlatform.API.DigitalFieldLog.Infrastructure.Persistence.EFC.Repositories;
using ElixirLinePlatform.API.ProductionHistory.Application.Internal.CommandServices;
using ElixirLinePlatform.API.ProductionHistory.Application.Internal.QueryServices;
using ElixirLinePlatform.API.ProductionHistory.Domain.Repositories;
using ElixirLinePlatform.API.ProductionHistory.Domain.Services;
using ElixirLinePlatform.API.ProductionHistory.Infrastructure.Persistence.EFC.Repositories;
using ElixirLinePlatform.API.Shared.Domain.Repositories;
using ElixirLinePlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using ElixirLinePlatform.API.SupplyInventory.Domain.Repositories;
using ElixirLinePlatform.API.SupplyInventory.Domain.Services;
using ElixirLinePlatform.API.SupplyInventory.Infrastructure.Persistence.EFC.Repositories;
using ElixirLinePlatform.API.SupplyInventory.Services;
using ElixirLinePlatform.API.WinemakingProcess.Application.Internal.CommandServices;
using ElixirLinePlatform.API.WinemakingProcess.Application.Internal.QueryServices;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Repositories;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Services;
using ElixirLinePlatform.API.WinemakingProcess.Infrastructure.Persistence.EFC.Repositories;
using ElixirLinePlatform.API.Shared.Domain.Events;
using ElixirLinePlatform.API.ProductionHistory.Application.Internal.EventHandlers;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Events;
using Microsoft.EntityFrameworkCore;
using ElixirLinePlatform.API.VinificationProcess.Domain.Repositories.AgriculturalActivities;
using ElixirLinePlatform.API.VinificationProcess.Domain.Services.AgriculturalActivities;
using ElixirLinePlatform.API.VinificationProcess.Infrastructure.Persistence.EFC.Repositories.AgriculturalActivities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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




//===================================== 1. Bounded Context: Winemaking Process

builder.Services.AddScoped<IWineBatchCommandService, WineBatchCommandService>();
builder.Services.AddScoped<IWineBatchQueryService, WineBatchQueryService>();
builder.Services.AddScoped<IWineBatchRepository, WineBatchRepository>();


//===================================== Bounded Context ===============================


//===================================== Supply Inventory Bounded Context ================================
builder.Services.AddScoped<ISupplyRepository, SupplyRepository>();
builder.Services.AddScoped<ISupplyUsageRepository, SupplyUsageRepository>();
builder.Services.AddScoped<ISupplyService, SupplyService>();
builder.Services.AddScoped<ISupplyUsageService, SupplyUsageService>();
//===================================== END Supply Inventory Bounded Context ===========================




//===================================== Bounded Context: Production History ===============================
builder.Services.AddScoped<IProductionRecordRepository, ProductionRecordRepository>();
builder.Services.AddScoped<IProductionRecordQueryService, ProductionRecordQueryService>();
builder.Services.AddScoped<IProductionRecordCommandService, ProductionRecordCommandService>();
builder.Services.AddScoped<IEventDispatcher, EventDispatcher>();
builder.Services.AddScoped<IEventHandler<WineBatchCompletedEvent>, WineBatchCompletedEventHandler>();

//===================================== Bounded Context: Production History ===============================


//===================================== 1. Gustavo Context ================================

builder.Services.AddScoped<IFieldLogEntryCommandService, FieldLogEntryCommandService>();
builder.Services.AddScoped<IFieldLogEntryRepository, FieldLogEntryRepository>();
builder.Services.AddScoped<IFieldLogEntryQueryService, FieldLogEntryQueryService>();

//===================================== End Gustavo bounded Context ===============================


//===================================== 1. Bounded Context ================================


//===================================== Bounded Context ===============================





//=================================== AgriculturalActivities Bounded Context ===============================

// Repositorios
builder.Services.AddScoped<IAgriculturalTaskRepository, AgriculturalTaskRepository>();
builder.Services.AddScoped<ITaskExecutionReportRepository, TaskExecutionReportRepository>();
builder.Services.AddScoped<ITaskNotificationRepository, TaskNotificationRepository>();
builder.Services.AddScoped<IParcelRepository, ParcelRepository>();

// Servicios de Dominio
builder.Services.AddScoped<IAgriculturalTaskService, AgriculturalTaskService>();
builder.Services.AddScoped<ITaskExecutionReportService, TaskExecutionReportService>();
builder.Services.AddScoped<ITaskNotificationService, TaskNotificationService>();
builder.Services.AddScoped<IParcelService, ParcelService>();

//=========================================================================================================

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