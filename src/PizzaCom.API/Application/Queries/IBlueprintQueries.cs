using PizzaCom.API.Models;

namespace PizzaCom.API.Queries;

public interface IBlueprintQueries
{
    Task<List<BlueprintCard>> GetBlueprintCards();
    Task<List<BlueprintBuilderRecipeItem>> GetIngredients();
    Task<BlueprintBuilderModel> GetBlueprintBuilder(BlueprintOptions options);
}