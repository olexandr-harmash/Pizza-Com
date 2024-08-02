using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaCom.Domain.AggregatesModel;

/// <summary>
/// Represents an ingredient in the pizza domain.
/// </summary>
public class Ingredient : Entity
{
    /// <summary>
    /// The name of the ingredient.
    /// </summary>
    private string _name;

    /// <summary>
    /// The cost of the ingredient.
    /// </summary>
    private decimal _cost;

    /// <summary>
    /// Navigation property. This field is used only for navigation and is ignored by the domain.
    /// </summary>
    private List<Recipe> _recipe;

    [NotMapped]
    /// <summary>
    /// The type of the ingredient.
    /// </summary>
    private IngredientType _type;

    /// <summary>
    /// Navigation property. This field is used only for navigation and is ignored by the domain.
    /// </summary>
    private int _ingredientTypeId;

    /// <summary>
    /// Navigation property. This field is used only for navigation and is ignored by the domain.
    /// </summary>
    private List<Blueprint> _blueprints;

    protected Ingredient() {}

    /// <summary>
    /// Initializes a new instance of the <see cref="Ingredient"/> class.
    /// </summary>
    /// <param name="name">The name of the ingredient.</param>
    /// <param name="cost">The cost of the ingredient.</param>
    /// <param name="type">The type of the ingredient.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> is null or empty.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="cost"/> is less than zero.</exception>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="type"/> is null.</exception>
    public Ingredient(string name, decimal cost, IngredientType type)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name), "Ingredient name cannot be null or empty.");
        }

        if (cost < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(cost), "Ingredient cost cannot be less than zero.");
        }

        _name = name;
        _cost = cost;
        _type = type ?? throw new ArgumentNullException(nameof(type), "Ingredient type cannot be null.");
        _ingredientTypeId = type.Id; //привязать к другому ключу публичному
    }

    /// <summary>
    /// Gets the name of the ingredient.
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// Gets the cost of the ingredient.
    /// </summary>
    public decimal Cost => _cost;

    /// <summary>
    /// Gets the type of the ingredient.
    /// </summary>
    public IngredientType Type => _type;
}