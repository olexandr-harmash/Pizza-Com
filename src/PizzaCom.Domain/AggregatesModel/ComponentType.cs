namespace PizzaCom.Domain.AggregatesModel;

/// <summary>
/// Represents the type of an ingredient in the pizza domain.
/// </summary>
public class ComponentType : Enumeration
{
    /// <summary>
    /// Represents a base ingredient that is always included in the pizza.
    /// </summary>
    public static ComponentType Default = new(1, nameof(Default));

    /// <summary>
    /// Represents an OptionServiceal ingredient that can be added to the pizza.
    /// </summary>
    public static ComponentType Optional = new(2, nameof(Optional));

    /// <summary>
    /// Initializes a new instance of the <see cref="ComponentType"/> class.
    /// </summary>
    /// <param name="id">The unique identifier for the ingredient type.</param>
    /// <param name="name">The name of the ingredient type.</param>
    public ComponentType(int id, string name)
        : base(id, name)
    {
    }
}