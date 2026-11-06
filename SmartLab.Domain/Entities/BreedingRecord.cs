using SmartLab.Domain.Enums;

namespace SmartLab.Domain.Entities;

public class BreedingRecord
{
    public int Id { get; set; }
    public int MaleId { get; set; }
    public Animal Male { get; set; } = null!;
    public int FemaleId { get; set; }
    public Animal Female { get; set; } = null!;
    public DateTime BreedingDate { get; set; }
    public BreedingResultStatus ResultStatus { get; set; }
    public int OffspringCount { get; set; }
}