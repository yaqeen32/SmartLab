using SmartLab.Domain.Entities;

namespace SmartLab.Domain.ValueObjects;

public class PedigreeTree
{
    public int AnimalId { get; set; }
    public Animal? Animal { get; set; }
    public List<PedigreeTree> Children { get; set; } = new();
    public List<PedigreeTree> Parents { get; set; } = new();
}