using System.Text.Json;
using ElixirLinePlatform.API.ProductionHistory.Domain.Model.Aggregate;
using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
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
      
      //=================================================================================================
      //===================================== 1. GONZALO BOUNDED CONTEXT ================================
      
   
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
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