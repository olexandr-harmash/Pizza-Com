namespace PizzaCom.Domain.AggregatesModel;

/// <summary>
/// Represents a blueprint for a pizza in the pizza domain.
/// </summary>
public class Blueprint : Entity, IAggregateRoot
{
    private string _name;
    private decimal _baseCost;
    private List<Recipe> _recipe;
    /// <summary>
    /// TODO: create individual structure for ingradient that do not connected with recipe and define aviable fetures.
    /// </summary>
    private List<Recipe> _included;

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
        _included = _recipe.Where(i => i.Type == RecipeType.Base).ToList();
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

    /// <summary>
    /// Gets the current ingredients for the pizza.
    /// </summary>
    public IReadOnlyCollection<Recipe> Ingredients => _included.AsReadOnly();

    /// <summary>
    /// Adds an ingredient to the pizza.
    /// </summary>
    /// <param name="ingredient">The ingredient to add.</param>
    /// <exception cref="ArgumentException">Thrown when the ingredient is not part of the recipe.</exception>
    public void AddIngredient(Recipe ingredient)
    {
        var recipeEntity = _recipe.Find(i => i.Equals(ingredient));

        if (recipeEntity is null)
        {
            throw new ArgumentException("Ingredient is not part of the recipe.");
        }

        _included.Add(ingredient);
    }

    /// <summary>
    /// Changes the weight of an ingredient in the recipe.
    /// </summary>
    /// <param name="ingredient">The ingredient to change the weight of.</param>
    /// <param name="weight">The new weight of the ingredient.</param>
    /// <exception cref="ArgumentException">Thrown when the ingredient is not part of the recipe.</exception>
    public void ChangeIngredientWeight(Recipe ingredient, int weight)
    {
        var recipeEntity = _recipe.Find(i => i.Equals(ingredient));

        if (recipeEntity is null)
        {
            throw new ArgumentException("Ingredient is not part of the recipe.");
        }

        recipeEntity.ChangeWeight(weight);
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
}
