namespace PizzaCom.Infrastructure.Repositories;

public interface IBoilerplateRepository
    : IRepository<Boilerplate>
{
    public Boilerplate Add(Boilerplate boilerplate);
    public Task<List<Boilerplate>> GetBoilerplateAsync();
    public Task<Boilerplate> GetBoilerplateDetailsByIdAsync(int id);
}