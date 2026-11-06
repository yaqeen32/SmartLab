using Microsoft.EntityFrameworkCore;
using SmartLab.Domain.Entities;

namespace SmartLab.Infrastructure.Data;

public class SmartLabDbContext : DbContext
{
    public DbSet<Animal> Animals { get; set; } = null!;
    public DbSet<MedicalRecord> MedicalRecords { get; set; } = null!;
    public DbSet<BreedingRecord> BreedingRecords { get; set; } = null!;
    public DbSet<InbreedingAnalysis> InbreedingAnalyses { get; set; } = null!;
    public DbSet<Strain> Strains { get; set; } = null!;
    public DbSet<Cage> Cages { get; set; } = null!;

    public SmartLabDbContext(DbContextOptions<SmartLabDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Animal entity configuration
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.UniqueId).IsRequired();
            entity.Property(e => e.Sex).IsRequired();
            entity.Property(e => e.Status).IsRequired();
            entity.Property(e => e.BirthDate).IsRequired();
            entity.Property(e => e.Weight).IsRequired();
            entity.Property(e => e.FatherId);
            entity.Property(e => e.MotherId);
            entity.HasOne(e => e.Strain).WithMany(e => e.Animals).HasForeignKey(e => e.StrainId);
            entity.HasOne(e => e.Cage).WithMany(e => e.Animals).HasForeignKey(e => e.CageId);
            entity.HasOne(e => e.Father).WithMany().HasForeignKey(e => e.FatherId);
            entity.HasOne(e => e.Mother).WithMany().HasForeignKey(e => e.MotherId);
            entity.HasMany(e => e.MedicalRecords).WithOne(e => e.Animal).HasForeignKey(e => e.AnimalId);
            entity.HasMany(e => e.BreedingRecords).WithOne(e => e.Male).HasForeignKey(e => e.MaleId);
            entity.HasMany(e => e.InbreedingAnalyses).WithOne(e => e.Male).HasForeignKey(e => e.MaleId);
            entity.HasMany(e => e.InbreedingAnalyses).WithOne(e => e.Female).HasForeignKey(e => e.FemaleId);
        });

        // MedicalRecord entity configuration
        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Treatment).IsRequired();
            entity.Property(e => e.Dose).IsRequired();
            entity.Property(e => e.Date).IsRequired();
            entity.Property(e => e.Vaccination);
        });

        // BreedingRecord entity configuration
        modelBuilder.Entity<BreedingRecord>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.MaleId).IsRequired();
            entity.Property(e => e.FemaleId).IsRequired();
            entity.Property(e => e.BreedingDate).IsRequired();
            entity.Property(e => e.ResultStatus).IsRequired();
        });

        // InbreedingAnalysis entity configuration
        modelBuilder.Entity<InbreedingAnalysis>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.MaleId).IsRequired();
            entity.Property(e => e.FemaleId).IsRequired();
            entity.Property(e => e.Score).IsRequired();
            entity.Property(e => e.Methodology).IsRequired();
            entity.Property(e => e.RiskFlag).IsRequired();
        });

        // Seed data
        modelBuilder.Entity<Strain>().HasData(new Strain
        {
            Id = 1,
            Name = "WT",
            Description = "Wild Type",
            CreatedAt = DateTime.UtcNow
        });

        modelBuilder.Entity<Cage>().HasData(new Cage
        {
            Id = 1,
            Name = "Cage A",
            StrainId = 1
        });
    }
}