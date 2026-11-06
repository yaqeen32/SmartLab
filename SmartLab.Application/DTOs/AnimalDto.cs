using SmartLab.Domain.Enums;

namespace SmartLab.Application.DTOs;

public class AnimalDto
{
    public int Id { get; set; }
    public string UniqueId { get; set; } = string.Empty;
    public AnimalSex Sex { get; set; }
    public AnimalStatus Status { get; set; }
    public DateTime BirthDate { get; set; }
    public double Weight { get; set; }
    public int StrainId { get; set; }
    public string StrainName { get; set; } = string.Empty;
    public int CageId { get; set; }
    public string CageName { get; set; } = string.Empty;
    public int? FatherId { get; set; }
    public int? MotherId { get; set; }
}