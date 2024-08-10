using System.Collections.Frozen;

namespace PizzaCom.Domain.AggregatesModel;

public class Boilerplate : Entity, IAggregateRoot
{
    private string _title;
    private decimal _price;
    private readonly List<Component> _components;
    private readonly Dictionary<Component, float> _componentsWithMultiplier;

    protected Boilerplate() 
    {
        _componentsWithMultiplier = new Dictionary<Component, float>();
    }

    public Boilerplate(string title, decimal price, List<Component> components) : this()
    { 
        _title = title;
        _price = price;
        _components = components;
    }

    public string Title => _title;

    public string Recipe => 
        string.Join(", ", _components.Select(c => c.Name.ToLower()));

    public decimal Price => _price;

    public IReadOnlyCollection<Component> Components => 
        _components.AsReadOnly();

    public IReadOnlyDictionary<Component, float> ComponentsWithMultiplier => 
            _componentsWithMultiplier.ToFrozenDictionary();

    /// <summary>
    /// Добавляет компонент или увеличивает его количество.
    /// </summary>
    /// <param name="component">Компонент, который нужно добавить.</param>
    public void AddComponent(Component component, float multiplier = 1)
    {
        if (_componentsWithMultiplier.ContainsKey(component))
        {
            _componentsWithMultiplier[component] += multiplier;
        }
        else
        {
            _componentsWithMultiplier[component] = multiplier;
        }
    }

    /// <summary>
    /// Удаляет компонент или уменьшает его количество.
    /// </summary>
    /// <param name="component">Компонент, который нужно удалить.</param>
    public void RemoveComponent(Component component, float multiplier = 1)
    {
        if (_componentsWithMultiplier.ContainsKey(component))
        {
            if (_componentsWithMultiplier[component] > 1)
            {
                _componentsWithMultiplier[component] -= multiplier;
            }
            else
            {
                _componentsWithMultiplier.Remove(component);
            }
        }
    }

    /// <summary>
    /// Устанавливает новую цену.
    /// </summary>
    /// <param name="newPrice">Новая цена для установки.</param>
    public void SetNewPrice(decimal newPrice)
    {
        _price = newPrice;
    }
}