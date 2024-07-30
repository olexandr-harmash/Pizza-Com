namespace PizzaCom.Domain.AggregatesModel;

public interface IBlueprintRepository
    : IRepository<Blueprint>
{
    public Blueprint Add(Blueprint blueprint);

    public Task<Blueprint> GetAsync(int blueprintId);

     public Task SaveChangesAsync();
}
