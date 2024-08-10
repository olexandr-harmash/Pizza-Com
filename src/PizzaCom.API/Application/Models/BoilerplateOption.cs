namespace PizzaCom.API.Models;

public class OptionDto2
{
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public bool CanApplyAgain { get; set; }
    public int MaxTimes { get; set; }
    public int CurrentTimesApplied { get; set; }
}