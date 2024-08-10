namespace PizzaCom.API.Models;

public class OptionDto
{
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public bool Applies { get; set; }
    public bool CanApplyAgain { get; set; }
    public int MaxTimes { get; set; }
    public int CurrentTimesApplied { get; set; }
}