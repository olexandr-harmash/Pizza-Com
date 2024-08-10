using PizzaCom.Domain.AggregatesModel;
using PizzaCom.Domain.BoilerplateOptionServices;

namespace PizzaCom.API.Factories;

public class BoilerplateFactory : IBoilerplateFactory
{
    public Boilerplate BoilerplateWithOptionServices(Boilerplate boilerplate, BoilerplateSetUpOptionServices OptionServices)
    {
        if (boilerplate is null)
            throw new KeyNotFoundException("Blueprint not found.");

        if (OptionServices.ExcludedIngredientIds.Any())
        {
            var components = boilerplate.Components.Where(c => 
                OptionServices.ExcludedIngredientIds.Contains(c.Id)).ToList();

            if (components.Count != OptionServices.ExcludedIngredientIds.Count)
            {
                throw new ArgumentException("No valid components found to exclude.");
            }

            foreach (var component in components)
            {
             
            }
        }

        if (OptionServices.AddDoubleMeatOptionService)
        {
     
        }

        if (OptionServices.AddCheeseRimOptionService)
        {
      
        }

        if (OptionServices.AddVeganOptionService)
        {
   
        }

        if (OptionServices.AddCornOptionService)
        {

        }

        return boilerplate;
    }

    private void ThrowIfOptionServiceAlreadyExists(bool OptionService)
    {
        if (OptionService == false)
        {
            throw new ArgumentException($"Invalid OptionService: {nameof(OptionService)}");
        }
    }
}