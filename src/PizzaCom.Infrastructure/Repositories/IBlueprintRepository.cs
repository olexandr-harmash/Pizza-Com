namespace PizzaCom.Infrastructure.Repositories;

public interface IBlueprintRepository
    : IRepository<Blueprint>
{
    public void Add(Blueprint b);

    public Task<Blueprint> GetAsync(int id);
}
