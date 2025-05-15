   using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Aggregate;
   using ElixirLinePlatform.API.DigitalFieldLog.Domain.Model.Entities;
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

         builder.UseSnakeCaseNamingConvention();
      }
   }