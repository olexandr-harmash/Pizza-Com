using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaCom.Domain.AggregatesModel;

/// <summary>
/// Represents a blueprint for a pizza in the pizza domain.
/// </summary>
public class Blueprint : Entity, IAggregateRoot
{
    /// <summary>
    /// The name of the ingredient.
    /// </summary>
    private string _name;

    /// <summary>
    /// The base cost of the ingredient.
    /// </summary>
    private decimal _baseCost;

    private readonly List<Recipe> _recipes;

    /// <summary>
    /// TODO: create individual structure for ingradient that do not connected with recipe and define aviable fetures.
    /// </summary>
    private readonly HashSet<Ingredient> _included;

    /// <summary>
    /// TODO: create individual structure for ingradient that do not connected with recipe and define aviable fetures.
    /// </summary>
    private readonly List<Ingredient> _excluded;

    /// <summary>
    /// Initializes a new instance of the <see cref="Blueprint"/> class.
    /// </summary>
    /// <param name="name">The name of the pizza blueprint.</param>
    /// <param name="baseCost">The base cost of the pizza.</param>
    /// <param name="recipe">The recipe for the pizza.</param>
    public Blueprint(int id, string name, decimal baseCost, List<Recipe> recipes)
    {
        Id = id;
        _name = name;
        _baseCost = baseCost;
        _recipes = recipes;
        _included = recipes.Select(r => new Ingredient(
            r.IngredientId,
            r.Name,
            r.CostPer100g,
            r.Weight,
            r.IngredientType
        )).ToHashSet();
        _excluded = new List<Ingredient>();
    }

    /// <summary>
    /// Gets the name of the pizza blueprint.
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// Gets the base cost of the pizza.
    /// </summary>
    public decimal BaseCost => _baseCost;

    /// <summary>
    /// Gets the recipe for the pizza.
    /// </summary>
    public IReadOnlyCollection<Recipe> Recipes => _recipes.AsReadOnly();

    /// <summary>
    /// Gets the current ingredients for the pizza.
    /// </summary>
    public IReadOnlyCollection<Ingredient> Included => _included.ToList().AsReadOnly();

    /// <summary>
    /// Gets the current ingredients that have been excluded from the pizza.
    /// </summary>
    public IReadOnlyCollection<Ingredient> Excluded => _excluded.AsReadOnly();

    /// <summary>
    /// Adds an ingredient to the pizza.
    /// </summary>
    /// <param name="ingredient">The ingredient to add to the pizza.</param>
    /// <exception cref="ArgumentException">Thrown when the ingredient is not part of the recipe or already exists in the included ingredients.</exception>
    public void AddIngredient(Ingredient ingredient)
    {
        // Find the recipe entry with the given ingredient
        var r = _recipes.FirstOrDefault(r => r.IngredientId == ingredient.Id);

        if (r is null)
        {
            throw new ArgumentException("Ingredient is not part of the recipe.");
        }

        // Try to add the ingredient to the included HashSet
        var isAdded = _included.Add(ingredient);

        // If the ingredient was not added, it means it already exists
        if (!isAdded)
        {
            throw new ArgumentException("Ingredient already exists in the pizza.");
        }
    }

    /// <summary>
    /// Changes the weight of an ingredient in the recipe.
    /// </summary>
    /// <param name="ingredient">The ingredient to change the weight of.</param>
    /// <param name="newWeight">The new weight of the ingredient.</param>
    /// <exception cref="ArgumentException">Thrown when the ingredient is not part of the included ingredients.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the new weight is less than zero.</exception>
    public void ChangeIngredientWeight(Ingredient ingredient, int newWeight)
    {
        // Find the ingredient in the included HashSet
        var i = _included.FirstOrDefault(i => i == ingredient);

        // Throw an exception if the ingredient is not found
        if (i is null)
        {
            throw new ArgumentException("The specified ingredient is not part of the included ingredients.");
        }

        // Validate the new weight
        if (newWeight < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(newWeight), "Weight cannot be less than zero.");
        }

        // Change the weight of the found ingredient
        i.Weight = newWeight;
    }

    /// <summary>
    /// Gets the total cost of the pizza, including base cost and ingredient costs.
    /// </summary>
    /// <returns>The total cost of the pizza.</returns>
    public decimal Cost => _included.Sum(i => i.Cost);


    /// <summary>
    /// Gets the total weight of the pizza based on its ingredients.
    /// </summary>
    /// <returns>The total weight of the pizza.</returns>
    public int Weight => _included.Sum(i => i.Weight);

    /// <summary>
    /// Exclude the ingredient in the recipe.
    /// </summary>
    /// <param name="ingredient">The ingredient to exclude.</param>
    /// <exception cref="ArgumentException">Thrown when the ingredient is not part of the recipe.</exception>
    public void ExcludeIngredient(Ingredient ingredient)
    {
        var i = _included.FirstOrDefault(i => i.Equals(ingredient));

        if (i == null)
        {
            throw new ArgumentException("Ingredient is not part of the included ingredients.");
        }

        _excluded.Add(i);
        _included.Remove(i);
    }
}
