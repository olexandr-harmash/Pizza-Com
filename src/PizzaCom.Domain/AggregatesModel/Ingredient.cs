namespace PizzaCom.Domain.AggregatesModel;

/// <summary>
/// Represents an ingredient in the pizza domain.
/// </summary>
public class Ingredient : IngredientBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Ingredient"/> class.
    /// </summary>
    /// <param name="name">The name of the ingredient.</param>
    /// <param name="costPer100g">The cost of the ingredient per 100g.</param>
    /// <param name="weight">The weight of the ingredient.</param>
    /// <param name="type">The type of the ingredient.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> is null or empty.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="costPer100g"/> is less than zero.</exception>
    public Ingredient(int id, string name, decimal costPer100g, int weight, IngredientType type)
        : base(id, name, costPer100g, weight, type)
    {
    }

    /// <summary>
    /// Gets the total cost of the ingredient based on its weight.
    /// </summary>
    public decimal Cost => _costPer100g * _weight / 100;

    public IngredientType Type => _ingredientType;

    /// <summary>
    /// Gets or sets the weight of the ingredient.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the weight is less than zero.</exception>
    public new int Weight
    {
        get => _weight;
        set
        {
            if (value < 0 || value > 200)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Weight cannot be out of range 0-200.");
            }
            _weight = value;
        }
    }
}