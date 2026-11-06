namespace SmartLab.Domain.Entities;

public class InbreedingAnalysis
{
    public int Id { get; set; }
    public int MaleId { get; set; }
    public Animal Male { get; set; } = null!;
    public int FemaleId { get; set; }
    public Animal Female { get; set; } = null!;
    public decimal Score { get; set; }
    public string Methodology { get; set; } = string.Empty;
    public bool RiskFlag { get; set; }
    public DateTime AnalysisDate { get; set; } = DateTime.UtcNow;
}