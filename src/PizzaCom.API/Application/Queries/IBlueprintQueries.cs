namespace PizzaCom.API.Queries;

public interface IBlueprintQueries
{
    Task<List<BoilerplateDTO>> GetBoilerplateDTOs();
    Task<PizzaTemplateDTO> GetBlueprintBuilder(int id, CreateOrUpdatePizzaTemplateRequestDTO OptionServices);
}