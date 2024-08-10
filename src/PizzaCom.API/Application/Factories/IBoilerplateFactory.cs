using PizzaCom.Domain.AggregatesModel;

namespace PizzaCom.API.Factories;

public interface IBoilerplateFactory
{
    Boilerplate BoilerplateWithOptionServices(Boilerplate boilerplate, BoilerplateSetUpOptionServices OptionServices);
}