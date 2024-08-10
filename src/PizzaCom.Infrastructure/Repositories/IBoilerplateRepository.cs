namespace PizzaCom.Infrastructure.Repositories;

public interface IBoilerplateRepository
    : IRepository<Boilerplate>
{
    public Boilerplate Add(Boilerplate boilerplate);
}