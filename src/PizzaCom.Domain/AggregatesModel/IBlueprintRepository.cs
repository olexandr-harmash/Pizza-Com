namespace PizzaCom.Domain.AggregatesModel;

public interface IBlueprintRepository
    : IRepository<Blueprint>
{
    public Blueprint Add(Blueprint blueprint);
}
