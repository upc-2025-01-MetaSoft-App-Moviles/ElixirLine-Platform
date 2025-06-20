using System.Text.Json;



using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;



using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities;

namespace ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        //Para campos de auditor (CreatedDate, UpdatedDate)
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
                 //=================================================================================================
         //||                                    CONFIGURATION OF THE TABLES                              ||                              
         //=================================================================================================
         
         //===================================== 1. GONZALO BOUNDED CONTEXT ================================
      
         // ======================= 1.1. WINE BATCH 
      
         
         
      
         
         
         
         
         
         
         
         // ======================= 1.2. WINEMAKING STAGES
      
         

         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
// Relación con WineBatch
         

         
         



         //=================================================================================================
         //===================================== 1. Gustavo BOUNDED CONTEXT ================================
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         // Usa el nombre correcto del campo clave

         
         
         
         
         
         
         
         
         
         
         
         
         
         
         //Regals de mapped object relational (ORM)

         
         //===================================== 1. END Gustavo BOUNDED CONTEXT ================================
         
         
         
         
         //=================================================================================================
         //===================================== 2. FERNANDO - SUPPLY INVENTORY BOUNDED CONTEXT =======================
      
         // Configuración de la entidad Supply
         
      
         
         
         
         
         
         
         // Configuración de la entidad SupplyUsage
         
         
         
         
         
         
         // Relación entre Supply y SupplyUsage
      
         
         
         
         
         
         //=================================================================================================

         
         
         
         
         //=================================================================================================
         //======================= Fabricio Apaza Bounded Context (Production History) =====================
      
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         

         //=================================================================================================
         //======================= Raul Quispe Bounded Context (planning activities) =====================


         builder.Entity<TaskNotification>(entity =>
         {
             entity.ToTable("TaskNotifications");
             entity.HasKey(e => e.NotificationId);
         });

        builder.Entity<AgriculturalTask>(entity =>
        {
            entity.HasKey(e => e.TaskId);
        });

        builder.Entity<Parcel>(entity =>
        {
            entity.ToTable("Parcels");
            entity.HasKey(e => e.ParcelId);
        });

        builder.Entity<TaskExecutionReport>(entity =>
        {
            entity.ToTable("TaskExecutionReports");
            entity.HasKey(e => e.ReportId);

            entity.HasMany(e => e.EvidencePhotos)
                .WithOne(p => p.Report)
                .HasForeignKey(p => p.ReportId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<EvidencePhoto>(entity =>
        {
            entity.ToTable("EvidencePhotos");
            entity.HasKey(e => e.EvidencePhotoId);
            entity.Property(e => e.PhotoUrl).IsRequired();
        });
         
        builder.UseSnakeCaseNamingConvention();
    }
    public DbSet<TaskNotification> TaskNotifications { get; set; }
    public DbSet<AgriculturalTask> AgriculturalTasks { get; set; }
    public DbSet<Parcel> Parcels { get; set; }
    public DbSet<TaskExecutionReport> TaskExecutionReports { get; set; }
    public DbSet<EvidencePhoto> EvidencePhotos { get; set; }
}