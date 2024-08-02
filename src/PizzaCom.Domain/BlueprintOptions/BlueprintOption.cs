using PizzaCom.Domain.AggregatesModel;

namespace PizzaCom.API.Domain.BlueprintOptions;

/// <summary>
/// Represents an abstract base class for blueprint options.
/// </summary>
public abstract class BlueprintOption
{
    /// <summary>
    /// The blueprint to which the option is applied.
    /// </summary>
    protected readonly Blueprint _blueprint;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlueprintOption"/> class.
    /// </summary>
    /// <param name="blueprint">The blueprint to which the option is applied.</param>
    protected BlueprintOption(Blueprint blueprint)
    {
        _blueprint = blueprint ?? throw new ArgumentNullException(nameof(blueprint));
    }

    /// <summary>
    /// Gets the name of the option.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Gets a value indicating whether the option is available.
    /// </summary>
    public abstract bool IsAvailable { get; }

    /// <summary>
    /// Gets the price of the option.
    /// </summary>
    public abstract decimal Price { get; }

    /// <summary>
    /// Executes the option, applying it to the blueprint.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the option cannot be executed (e.g., if it is not available).
    /// </exception>
    public abstract void ExecuteOption();
}
