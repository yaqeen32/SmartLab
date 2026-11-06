namespace SmartLab.Domain.Entities;

public class Cage
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Strain? Strain { get; set; }
    public int? StrainId { get; set; }

    public ICollection<Animal> Animals { get; set; } = new List<Animal>();
}