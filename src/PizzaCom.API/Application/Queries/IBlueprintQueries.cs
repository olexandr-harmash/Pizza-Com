using PizzaCom.API.Models;

namespace PizzaCom.API.Queries;

public interface IBlueprintQueries
{
    Task<List<BlueprintCard>> GetBlueprintCards();

    Task<BlueprintBuilderModel> GetBlueprintBuilder(BuildBoilerplateDTO OptionServices);
}