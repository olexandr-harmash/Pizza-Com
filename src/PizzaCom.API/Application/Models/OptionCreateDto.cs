namespace PizzaCom.API.Models;

public class OptionCreateDto
{
    public string Name { get; set; }
    public int CurrentTimesApplied { get; set; }

    public string GetHashCode()
    {
        return Name;
    }
}