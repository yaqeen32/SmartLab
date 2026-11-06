namespace SmartLab.Domain.Entities;

public class MedicalRecord
{
    public int Id { get; set; }
    public int AnimalId { get; set; }
    public Animal Animal { get; set; } = null!;
    public string Treatment { get; set; } = string.Empty;
    public string Dose { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public bool Vaccination { get; set; }
    public string HealthObservations { get; set; } = string.Empty;
}