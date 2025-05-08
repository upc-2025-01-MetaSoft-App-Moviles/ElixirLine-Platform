using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using ElixirLinePlatform.API.VinificationProcess.Domain.Model.Aggregate;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;


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
      
      //=================================================================================================
      //===================================== 1. GONZALO BOUNDED CONTEXT ================================
      
      // ======================= 1.1. WINE BATCH 
      
      builder.Entity<WineBatch>().HasKey(wb => wb.Id);
      builder.Entity<WineBatch>().Property(wb => wb.Id).IsRequired().ValueGeneratedOnAdd();
      
      builder.Entity<WineBatch>().Property(wb => wb.InternalCode).IsRequired().HasMaxLength(100);
      builder.Entity<WineBatch>().Property(wb => wb.HarvestCampaign).IsRequired().HasMaxLength(100);
      builder.Entity<WineBatch>().Property(wb => wb.VineyardOrigin).IsRequired().HasMaxLength(100);
      builder.Entity<WineBatch>().Property(wb => wb.GrapeVariety).IsRequired().HasMaxLength(100);
      builder.Entity<WineBatch>().Property(wb => wb.CreatedBy).IsRequired().HasMaxLength(100);
      builder.Entity<WineBatch>().Property(wb => wb.Status).IsRequired();
      
      // ======================= 1.2. WINEMAKING STAGES
      
      builder.Entity<WinemakingStage>()
         .HasKey(ws => ws.Id);

      builder.Entity<WinemakingStage>()
         .Property(ws => ws.Id).ValueGeneratedOnAdd();

      builder.Entity<WinemakingStage>()
         .Property(ws => ws.StartedAt).IsRequired();

      builder.Entity<WinemakingStage>()
         .Property(ws => ws.StageType).IsRequired();

      builder.Entity<WinemakingStage>()
         .HasDiscriminator<string>("stage_discriminator")
         .HasValue<ReceptionStage>("Reception")
         .HasValue<FermentationStage>("Fermentation");

// Relación con WineBatch
      builder.Entity<WinemakingStage>()
         .HasOne<WineBatch>()
         .WithMany(wb => wb.WinemakingStages)
         .HasForeignKey("WineBatchId");

      
      
      
      
      
      
      
      
      //Regals de mapped object relational (ORM)
      builder.UseSnakeCaseNamingConvention();
   }
}