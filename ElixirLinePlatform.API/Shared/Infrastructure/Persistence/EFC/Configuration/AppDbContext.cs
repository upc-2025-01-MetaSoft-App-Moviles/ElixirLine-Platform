using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;
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
      
      builder.Entity<WineBatch>().Property(wb => wb.UserId).IsRequired().HasMaxLength(100);

      builder.Entity<WineBatch>().Property(wb => wb.InternalCode).IsRequired().HasMaxLength(100);
      builder.Entity<WineBatch>().Property(wb => wb.HarvestCampaign).IsRequired().HasMaxLength(100);
      builder.Entity<WineBatch>().Property(wb => wb.VineyardOrigin).IsRequired().HasMaxLength(100);
      builder.Entity<WineBatch>().Property(wb => wb.GrapeVariety).IsRequired().HasMaxLength(100);
      builder.Entity<WineBatch>().Property(wb => wb.CreatedBy).IsRequired().HasMaxLength(100);
      builder.Entity<WineBatch>().Property(wb => wb.CampaignId).IsRequired().HasMaxLength(100);
      
      builder.Entity<WineBatch>()
         .Property(wb => wb.CurrentStage)
         .HasConversion<string>(); // 👈 Esto convierte el enum a string automáticamente

      // ======================= 1.2. WINEMAKING STAGES

      builder.Entity<WinemakingStage>()
         .HasKey(ws => ws.Id);

      builder.Entity<WinemakingStage>()
         .Property(ws => ws.Id).ValueGeneratedOnAdd();
      
      builder.Entity<WinemakingStage>()
         .Property(ws => ws.StageType)
         .IsRequired()
         .HasConversion<string>(); // Opcional: para guardar como texto

      builder.Entity<WinemakingStage>()
         .HasDiscriminator<string>("stage_discriminator")
         .HasValue<ReceptionStage>("Reception")
         .HasValue<CorrectionStage>("Correction")
         .HasValue<FermentationStage>("Fermentation")
         .HasValue<PressingStage>("Pressing")
         .HasValue<ClarificationStage>("Clarification")
         .HasValue<AgingStage>("Aging")
         .HasValue<FiltrationStage>("Filtration")
         .HasValue<BottlingStage>("Bottling");
      

      // Relación con WineBatch usando la propiedad real BatchId
      builder.Entity<WinemakingStage>()
         .HasOne<WineBatch>()
         .WithMany(wb => wb.WinemakingStages)
         .HasForeignKey(ws => ws.BatchId);

      
      
      
      
      
      
      
      
      //Regals de mapped object relational (ORM)
      builder.UseSnakeCaseNamingConvention();
   }
}