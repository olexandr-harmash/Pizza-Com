using PizzaCom.Domain.SeedWork;

namespace PizzaCom.Domain.AggregatesModel;

/// <summary>
/// Represents the type of an ingredient in the pizza domain.
/// </summary>
public class RecipeType : Enumeration
{
    /// <summary>
    /// Represents a base ingredient that is always included in the pizza.
    /// </summary>
    public static RecipeType Base = new(1, nameof(Base));

    /// <summary>
    /// Represents an optional ingredient that can be added to the pizza.
    /// </summary>
    public static RecipeType Optional = new(2, nameof(Optional));

    /// <summary>
    /// Represents an excludable ingredient that can be removed from the pizza.
    /// </summary>
    public static RecipeType Excludable = new(3, nameof(Excludable));

    /// <summary>
    /// Initializes a new instance of the <see cref="RecipeType"/> class.
    /// </summary>
    /// <param name="id">The unique identifier for the ingredient type.</param>
    /// <param name="name">The name of the ingredient type.</param>
    public RecipeType(int id, string name)
        : base(id, name)
    {
    }
}