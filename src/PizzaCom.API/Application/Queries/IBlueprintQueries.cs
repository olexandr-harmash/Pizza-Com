using PizzaCom.API.Models;

namespace PizzaCom.API.Queries;

public interface IBlueprintQueries
{
    Task<List<BlueprintCard>> GetBlueprintCards();

    Task<BoilerplateDetails> GetBoilerplateDetails(int id);

    Task<PizzaTemplateDTO> GetBlueprintBuilder(CreateOrUpdatePizzaTemplateRequestDTO OptionServices);
}