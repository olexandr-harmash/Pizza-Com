namespace PizzaCom.Domain.AggregatesModel;

/// <summary>
/// Represents a base class for common properties and methods used by Recipe and Ingredient.
/// </summary>
public abstract class IngredientBase : Entity
{
    /// <summary>
    /// The name of the entity.
    /// </summary>
    protected string _name;

    /// <summary>
    /// The cost per 100g of the entity.
    /// </summary>
    protected decimal _costPer100g;

    /// <summary>
    /// The weight of the entity.
    /// </summary>
    protected int _weight;

    /// <summary>
    /// The type of the ingredient.
    /// </summary>
    protected IngredientType _ingredientType;

    /// <summary>
    /// Initializes a new instance of the <see cref="IngredientBase"/> class.
    /// </summary>
    /// <param name="name">The name of the entity.</param>
    /// <param name="costPer100g">The cost per 100g of the entity.</param>
    /// <param name="weight">The weight of the entity.</param>
    /// <param name="ingredientType">The type of the ingredient.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> is null or empty.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="costPer100g"/> is less than zero.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="weight"/> is out of allowed range.</exception>
    protected IngredientBase(int id, string name, decimal costPer100g, int weight, IngredientType ingredientType)
    {
        Id = id;

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name), "Name cannot be null or empty.");
        }

        if (costPer100g < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(costPer100g), "Cost per 100g cannot be less than zero.");
        }

        if (weight < 0 || weight > 200)
        {
            throw new ArgumentOutOfRangeException(nameof(weight), "Weight cannot be out of range 0-200.");
        }

        _name = name;
        _costPer100g = costPer100g;
        _weight = weight;
        _ingredientType = ingredientType ?? throw new ArgumentNullException(nameof(ingredientType), "Ingredient type cannot be null.");
    }

    /// <summary>
    /// Gets the name of the entity.
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// Gets the cost per 100g of the entity.
    /// </summary>
    public decimal CostPer100g => _costPer100g;

    /// <summary>
    /// Gets the weight of the entity.
    /// </summary>
    public int Weight => _weight;

    /// <summary>
    /// Gets the type of the ingredient.
    /// </summary>
    public IngredientType IngredientType => _ingredientType;
}