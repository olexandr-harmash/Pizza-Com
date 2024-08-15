namespace PizzaCom.API.Queries.Models;

public class AppliedOptionDTO
{
    public string Name { get; set; }
    public int MaxTimesApplicable { get; set; }
    public bool IsApplicable { get; set; }
    public decimal TotalCost { get; set; }
    public int TimesApplied { get; set; }
}