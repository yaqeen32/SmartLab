using SmartLab.Domain.Enums;

namespace SmartLab.Domain.Entities;

public class Animal
{
    public int Id { get; set; }
    public string UniqueId { get; set; } = string.Empty;
    public AnimalSex Sex { get; set; }
    public AnimalStatus Status { get; set; }
    public DateTime BirthDate { get; set; }
    public double Weight { get; set; }
    public int StrainId { get; set; }
    public Strain Strain { get; set; } = null!;
    public int CageId { get; set; }
    public Cage Cage { get; set; } = null!;
    public int? FatherId { get; set; }
    public Animal? Father { get; set; }
    public int? MotherId { get; set; }
    public Animal? Mother { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
    public ICollection<BreedingRecord> BreedingRecords { get; set; } = new List<BreedingRecord>();
    public ICollection<InbreedingAnalysis> InbreedingAnalyses { get; set; } = new List<InbreedingAnalysis>();
}