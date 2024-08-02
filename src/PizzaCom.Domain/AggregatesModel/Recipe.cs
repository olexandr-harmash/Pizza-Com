using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaCom.Domain.AggregatesModel;

//TODO: rename that represent item in recipe but not recipe
/// <summary>
/// Represents a recipe for a pizza, including ingredient and its weight.
/// </summary>
public class Recipe : Entity
{
    /// <summary>
    /// Foreign key to the Blueprint entity. This field is used only for navigation and is ignored by the domain.
    /// </summary>
    private int _blueprintId;

    /// <summary>
    /// Foreign key to the Ingredient entity. This field is used only for navigation and is ignored by the domain.
    /// </summary>
    private int _ingredientId;

    /// <summary>
    /// Weight of the ingredient in the recipe.
    /// </summary>
    private int _weight;

    [NotMapped]
    /// <summary>
    /// Type of the recipe.
    /// </summary>
    private RecipeType _type;

    /// <summary>
    /// Navigation property. This field is used only for navigation and is ignored by the domain.
    /// </summary>
    private int _recipeTypeId;

    /// <summary>
    /// Navigation property to the Blueprint entity. This field is used only for navigation and is ignored by the domain.
    /// </summary>
    private Blueprint _blueprint;

    [NotMapped]
    /// <summary>
    /// Ingredient entity.
    /// </summary>
    public Ingredient _ingredient;

    protected Recipe() {}

    /// <summary>
    /// Initializes a new instance of the <see cref="Recipe"/> class.
    /// </summary>
    /// <param name="ingredient">The ingredient of the recipe.</param>
    /// <param name="weight">The weight of the ingredient in the recipe.</param>
    /// <param name="type">The type of the recipe entry.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ingredient"/> is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="weight"/> is less than zero or exceeds the allowed maximum weight.</exception>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="type"/> is null.</exception>
    public Recipe(Ingredient ingredient, int weight, RecipeType type)
    {
        _ingredient = ingredient ?? throw new ArgumentNullException(nameof(ingredient), "Ingredient cannot be null.");
        
        if (weight < 0 || weight > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(weight), "Weight must be between 0 and 100.");
        }

        _weight = weight;
        _type = type ?? throw new ArgumentNullException(nameof(type), "Recipe type cannot be null.");
        _recipeTypeId = type.Id;
        _ingredientId = ingredient.Id;
    }

    /// <summary>
    /// Gets the type of the recipe.
    /// </summary>
    public RecipeType Type => _type;
    
    //TODO: make field private and only for navigation, use recipe model as ingredient with additional recipe information.
    /// <summary>
    /// Gets the ingredient of the recipe.
    /// </summary>
    public Ingredient Ingredient => _ingredient;

    /// <summary>
    /// Gets the weight of the ingredient in the recipe.
    /// </summary>
    public int Weight => _weight;

    /// <summary>
    /// Changes the weight of the ingredient in the recipe.
    /// </summary>
    /// <param name="weight">The new weight of the ingredient.</param>
    /// <exception cref="ArgumentException">Thrown when the weight is less than 0 or greater than 100.</exception>
    public void ChangeWeight(int weight)
    {
        if (weight < 0 || weight > 100)
        {
            throw new ArgumentException("Weight must be between 0 and 100.");
        }

        _weight = weight;
    }
}