// using PizzaCom.Domain.AggregatesModel;

// namespace PizzaCom.Domain.Services;

// /// <summary>
// /// Service for managing blueprint operations.
// /// </summary>
// public class BlueprintService
// {
//     private readonly Blueprint _blueprint;

//     /// <summary>
//     /// Initializes a new instance of the <see cref="BlueprintService"/> class.
//     /// </summary>
//     /// <param name="blueprint">The blueprint to manage.</param>
//     public BlueprintService(Blueprint blueprint)
//     {
//         _blueprint = blueprint ?? throw new ArgumentNullException(nameof(blueprint));
//     }

//     /// <summary>
//     /// Checks if the double meat option is available in the blueprint.
//     /// </summary>
//     /// <returns>True if double meat option is available; otherwise, false.</returns>
//     public bool IsDoubleMeatOptionAvailable()
//     {
//         return _blueprint.Recipe.Any(r => r.Ingredient.Type == IngredientType.Meat);
//     }

//     /// <summary>
//     /// Executes the double meat option by doubling the weight of all meat ingredients in the blueprint's ingredients.
//     /// </summary>
//     /// <exception cref="InvalidOperationException">Thrown when no meat ingredients are found in the recipe.</exception>
//     public void ExecuteDoubleMeatOption(int times)
//     {
//         var meatIngredients = _blueprint.Recipe
//             .Where(r => r.Ingredient.Type == IngredientType.Meat)
//             .ToList();

//         if (!meatIngredients.Any())
//         {
//             throw new InvalidOperationException("No meat ingredients found in the recipe.");
//         }

//         foreach (var meatIngredient in meatIngredients)
//         {
//             _blueprint.ChangeIngredientWeight(new Component(meatIngredient), meatIngredient.Weight * times);
//         }
//     }

//     /// <summary>
//     /// Checks if corn can be added to the blueprint.
//     /// </summary>
//     /// <returns>True if corn is available in the recipe; otherwise, false.</returns>
//     public bool IsCornOptionAvailable()
//     {
//         return _blueprint.Recipe.Any(r => r.Ingredient.Name.Equals("Corn", StringComparison.OrdinalIgnoreCase));
//     }

//     /// <summary>
//     /// Adds corn to the blueprint's ingredients if available.
//     /// </summary>
//     /// <exception cref="InvalidOperationException">Thrown when corn is not found in the recipe.</exception>
//     public void AddCornOption()
//     {
//         var cornIngredient = _blueprint.Recipe
//             .FirstOrDefault(r => r.Ingredient.Name.Equals("Corn", StringComparison.OrdinalIgnoreCase));

//         if (cornIngredient == null)
//         {
//             throw new InvalidOperationException("Corn is not available in the recipe.");
//         }

//         _blueprint.AddIngredientById(cornIngredient.Id);
//     }
// }