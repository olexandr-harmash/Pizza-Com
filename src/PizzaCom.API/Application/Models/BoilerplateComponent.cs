namespace PizzaCom.API.Models;

public class ComponentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } // "Mandatory" or "Optional"
    public decimal Cost { get; set; }
    public int Quantity { get; set; }
    public bool Selected { get; set; }
}
