   using System.Text.Json;
   using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Aggregate;
   using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Entities;
   using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Aggregate;
   using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
   using ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;
   using ElixirLinePlatform.API.VinificationProcess.Domain.Model.Aggregate;
   using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;
   using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
   using Microsoft.EntityFrameworkCore;


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
            .HasValue<FermentationStage>("Fermentation")
            .HasValue<PressingStage>("Pressing");

// Relación con WineBatch
         builder.Entity<WinemakingStage>()
            .HasOne<WineBatch>()
            .WithMany(wb => wb.WinemakingStages)
            .HasForeignKey("WineBatchId");

         
         
         //=================================================================================================
         //===================================== 1. Gustavo BOUNDED CONTEXT ================================
         
         
         builder.Entity<FieldLogEntry>().HasKey(f => f.EntryId);
         builder.Entity<FieldLogEntry>().Property(f => f.EntryId)
            .IsRequired()
            .ValueGeneratedOnAdd();

         builder.Entity<FieldLogEntry>().Property(f => f.AuthorId)
            .IsRequired();

         builder.Entity<FieldLogEntry>().Property(f => f.ParcelId)
            .IsRequired();

         builder.Entity<FieldLogEntry>().Property(f => f.Description)
            .IsRequired()
            .HasMaxLength(500);
         
         builder.Entity<FieldIssue>().HasKey(f => f.IssueId); // Usa el nombre correcto del campo clave
         // Usa el nombre correcto del campo clave

         builder.Entity<FieldLogEntry>().Property(f => f.EntryType)
            .IsRequired();

         builder.Entity<FieldLogEntry>().Property(f => f.Timestamp)
            .IsRequired();

         builder.Entity<FieldLogEntry>()
            .Property(f => f.PhotoUrls)
            .HasConversion(
               v => string.Join(';', v),           // Convierte lista a string
               v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList() // Convierte string a lista
            )
            .HasColumnName("PhotoUrls");
         
         //Regals de mapped object relational (ORM)

         
         //===================================== 1. END Gustavo BOUNDED CONTEXT ================================
         
         
         
         
         //=================================================================================================
         //===================================== 2. FERNANDO - SUPPLY INVENTORY BOUNDED CONTEXT =======================
      
         // Configuración de la entidad Supply
         builder.Entity<Supply>().ToTable("Supplies");
         builder.Entity<Supply>().HasKey(s => s.Id);
         builder.Entity<Supply>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
         builder.Entity<Supply>().Property(s => s.Name).IsRequired().HasMaxLength(100);
         builder.Entity<Supply>().Property(s => s.Category).IsRequired().HasMaxLength(50);
         builder.Entity<Supply>().Property(s => s.Quantity).IsRequired().HasPrecision(18, 2);
         builder.Entity<Supply>().Property(s => s.Unit).IsRequired().HasMaxLength(20);
      
         // Configuración de la entidad SupplyUsage
         builder.Entity<SupplyUsage>().ToTable("SupplyUsages");
         builder.Entity<SupplyUsage>().HasKey(su => su.Id);
         builder.Entity<SupplyUsage>().Property(su => su.Id).IsRequired().ValueGeneratedOnAdd();
         builder.Entity<SupplyUsage>().Property(su => su.QuantityUsed).IsRequired().HasPrecision(18, 2);
         builder.Entity<SupplyUsage>().Property(su => su.Notes).HasMaxLength(500);
      
         // Relación entre Supply y SupplyUsage
         builder.Entity<SupplyUsage>()
            .HasOne(su => su.Supply)
            .WithMany(s => s.SupplyUsages)
            .HasForeignKey(su => su.SupplyId)
            .OnDelete(DeleteBehavior.Restrict);
      
         //=================================================================================================

         
         
         
         
         //=================================================================================================
         //======================= Fabricio Apaza Bounded Context (Production History) =====================
      
         builder.Entity<ProductionRecord>(entity =>
         {
            entity.ToTable("production_records");
            entity.HasKey(e => e.RecordId);
            entity.Property(e => e.RecordId).ValueGeneratedOnAdd();
            entity.Property(e => e.BatchId).IsRequired();
            entity.Property(e => e.StartDate).IsRequired();
            entity.Property(e => e.EndDate).IsRequired();
            entity.Property(e => e.VolumeProduced).IsRequired();
            entity.Property(e => e.QualityMetrics)
               .HasColumnType("json")
               .HasConversion(
                  v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                  v => JsonSerializer.Deserialize<Dictionary<string, float>>(v, (JsonSerializerOptions)null) ?? new Dictionary<string, float>()
               );
         });
         //Regals de mapped object relational (ORM)
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         

         builder.UseSnakeCaseNamingConvention();
      }
   }