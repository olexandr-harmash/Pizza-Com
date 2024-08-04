namespace PizzaCom.Domain.AggregatesModel;

//TODO: rename that represent item in recipe but not recipe and inherit base class with ingredient
 /// <summary>
    /// Represents a recipe for a pizza, including ingredient and its weight.
    /// </summary>
    public class Recipe : IngredientBase
    {
        /// <summary>
        /// Foreign key to the Ingredient entity. This field is used only for navigation and is ignored by the domain.
        /// </summary>
        private int _ingredientId;

        /// <summary>
        /// Type of the recipe.
        /// </summary>
        private RecipeType _type;

        /// <summary>
        /// Initializes a new instance of the <see cref="Recipe"/> class.
        /// </summary>
        /// <param name="ingredientId">The ingredient id of the recipe.</param>
        /// <param name="costPer100g">The cost per 100g of the ingredient.</param>
        /// <param name="weight">The weight of the ingredient in the recipe.</param>
        /// <param name="name">The name of the recipe.</param>
        /// <param name="type">The type of the recipe entry.</param>
        /// <param name="ingredientType">The type of the ingredient.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="type"/> is null.</exception>
        public Recipe(int id, int ingredientId, decimal costPer100g, int weight, string name, RecipeType type, IngredientType ingredientType)
            : base(id, name, costPer100g, weight, ingredientType)
        {
            if (weight < 0 || weight > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(weight), "Weight must be between 0 and 100.");
            }

            _ingredientId = ingredientId;
            _type = type ?? throw new ArgumentNullException(nameof(type), "Recipe type cannot be null.");
        }

        /// <summary>
        /// Gets the type of the recipe.
        /// </summary>
        public RecipeType Type => _type;

        public int IngredientId => _ingredientId;
}