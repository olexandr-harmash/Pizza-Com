namespace PizzaCom.API.Queries;

public interface IPizzaQueries
{
    Task<List<PizzaDTO>> GetPizzaDTOs();
    Task<PizzaDetailsDTO> GetPizzaDetails(int id);
    Task<PizzaTemplateDTO> GetPizzaTemplate(int id, GetPizzaTemplateDTO request);
}