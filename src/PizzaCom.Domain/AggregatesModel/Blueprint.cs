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

    [NotMapped]
    private readonly List<Recipe> _recipe;

    [NotMapped]
    /// <summary>
    /// TODO: create individual structure for ingradient that do not connected with recipe and define aviable fetures.
    /// </summary>
    private readonly HashSet<Recipe> _included;

    /// <summary>
    /// Ingredient entities. This field is used only for navigation and is ignored by the domain.
    /// </summary>
    private List<Ingredient> _ingredients;


    protected Blueprint() {}

    /// <summary>
    /// Initializes a new instance of the <see cref="Blueprint"/> class.
    /// </summary>
    /// <param name="name">The name of the pizza blueprint.</param>
    /// <param name="baseCost">The base cost of the pizza.</param>
    /// <param name="recipe">The recipe for the pizza.</param>
    public Blueprint(string name, decimal baseCost, List<Recipe> recipe)
    {
        _name = name;
        _baseCost = baseCost;
        _recipe = recipe;
        _included = _recipe.Where(i => i.Type == RecipeType.Base).ToHashSet();
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
    public IReadOnlyCollection<Recipe> Recipe => _recipe.AsReadOnly();

    [NotMapped]
    /// <summary>
    /// Gets the current ingredients for the pizza.
    /// </summary>
    public IReadOnlyCollection<Recipe> Included => _included.ToList().AsReadOnly();

    /// <summary>
    /// Adds an ingredient to the pizza.
    /// </summary>
    /// <param name="ingredient">The ingredient to add.</param>
    /// <exception cref="ArgumentException">Thrown when the ingredient is not part of the recipe or already exists in the included ingredients.</exception>
    public void AddIngredient(Recipe recipe)
    {
        // Check if the ingredient is part of the recipe
        var recipeEntity = _recipe.FirstOrDefault(i => i.Ingredient.Equals(recipe.Ingredient));

        if (recipeEntity is null)
        {
            throw new ArgumentException("Ingredient is not part of the recipe.");
        }

        // Try to add the ingredient to the included list
        var isAdded = _included.Add(recipe);

        //If the ingredient was not added, it means it already exists
        if (!isAdded)
        {
            throw new ArgumentException("Ingredient already exists in the pizza.");
        }
    }

    /// <summary>
    /// Changes the weight of an ingredient in the recipe.
    /// </summary>
    /// <param name="ingredient">The ingredient to change the weight of.</param>
    /// <param name="weight">The new weight of the ingredient.</param>
    /// <exception cref="ArgumentException">Thrown when the ingredient is not part of the recipe.</exception>
    public void ChangeIngredientWeight(Recipe ingredient, int weight)
    {
        var includedEntity = _included.FirstOrDefault(i => i.Equals(ingredient));

        if (includedEntity is null)
        {
            throw new ArgumentException("Ingredient is not part of the included ingredients.");
        }

        includedEntity.ChangeWeight(weight);
    }

    /// <summary>
    /// Gets the total cost of the pizza, including base cost and ingredient costs.
    /// </summary>
    /// <returns>The total cost of the pizza.</returns>
    public decimal CalculateTotalCost()
    {
        return _included.Sum(i => i.Ingredient.Cost * i.Weight / 100);
    }

    /// <summary>
    /// Gets the total weight of the pizza based on its ingredients.
    /// </summary>
    /// <returns>The total weight of the pizza.</returns>
    public int CalculateTotalWeight()
    {
        return _included.Sum(i => i.Weight);
    }

    /// <summary>
    /// Exclude the ingredient in the recipe.
    /// </summary>
    /// <param name="recipe">The ingredient to exclude.</param>
    /// <exception cref="ArgumentException">Thrown when the ingredient is not part of the recipe.</exception>
    public void ExcludeIngredientById(int recipeId)
    {
        var recipe = _included.FirstOrDefault(r => r.Ingredient.Id == recipeId);

        if (recipe == null)
        {
            throw new ArgumentException("Ingredient is not part of the included ingredients.");
        }

        _included.Remove(recipe);
    }
}
