namespace PizzaCom.API.Queries.Models;

public class IngredientDTO
{
    public int IngredientId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } // Enum: Default, Optional, Excluded
    public decimal AdditionalCost { get; set; }
}