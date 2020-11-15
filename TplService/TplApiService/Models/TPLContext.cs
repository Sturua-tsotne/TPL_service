using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tpl.Api.Models.Db_Models;

namespace Tpl.Api.Models
{
   
    public partial class TPLContext : DbContext
    {
        public TPLContext()
        {
        }

        public TPLContext(DbContextOptions<TPLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarFeature> CarFeatures { get; set; }
        public virtual DbSet<CarManufacturer> CarManufacturers { get; set; }
        public virtual DbSet<CarManufacturerCarModel> CarManufacturerCarModels { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<PersonalInformation> PersonalInformations { get; set; }
        public virtual DbSet<TplLimit> TplLimits { get; set; }
        public virtual DbSet<TplModel> TplModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarFeature>(entity =>
            {
                entity.Property(e => e.RegistrationNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CarManufacturer>(entity =>
            {
                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CarManufacturerCarModel>(entity =>
            {
                entity.HasKey(e => new { e.CarManufacturersId, e.CarModelsId });

                entity.ToTable("CarManufacturerCarModel");

                entity.HasIndex(e => e.CarModelsId, "IX_CarManufacturerCarModel_CarModelsId");

                entity.HasOne(d => d.CarManufacturers)
                    .WithMany(p => p.CarManufacturerCarModels)
                    .HasForeignKey(d => d.CarManufacturersId);

                entity.HasOne(d => d.CarModels)
                    .WithMany(p => p.CarManufacturerCarModels)
                    .HasForeignKey(d => d.CarModelsId);
            });

            modelBuilder.Entity<CarModel>(entity =>
            {
                entity.HasIndex(e => e.CarFeatureId, "IX_CarModels_CarFeatureId");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CarFeature)
                    .WithMany(p => p.CarModels)
                    .HasForeignKey(d => d.CarFeatureId);
            });

            modelBuilder.Entity<PersonalInformation>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.IdentityImg)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PersonalNumber)
                    .IsRequired()
                    .HasMaxLength(11);
            });

            modelBuilder.Entity<TplLimit>(entity =>
            {
                entity.HasIndex(e => e.TplModelId, "IX_TplLimits_TplModelId");

                entity.Property(e => e.Bonus)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Limit)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.TplModel)
                    .WithMany(p => p.TplLimits)
                    .HasForeignKey(d => d.TplModelId);
            });

            modelBuilder.Entity<TplModel>(entity =>
            {
                entity.HasIndex(e => e.CarFeatureId, "IX_TplModels_CarFeatureId");

                entity.HasIndex(e => e.PersonalInformationId, "IX_TplModels_PersonalInformationId");

                entity.HasOne(d => d.CarFeature)
                    .WithMany(p => p.TplModels)
                    .HasForeignKey(d => d.CarFeatureId);

                entity.HasOne(d => d.PersonalInformation)
                    .WithMany(p => p.TplModels)
                    .HasForeignKey(d => d.PersonalInformationId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}
