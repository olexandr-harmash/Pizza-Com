namespace PizzaCom.API.Queries;

public class BoilerplateDTO
{
    public int Id  { get; init; }
    public string Name { get; init; }
    public string Recipe { get; init; }
    public decimal Price { get; init; }
}

public class PizzaTemplateDTO
{
    public string PizzaTemplateId { get; set; }
    public string PizzaTemplateName { get; set; }
    public List<IngredientDTO> Ingredients { get; set; }
    public List<OptionDTO> Options { get; set; }
    public decimal TotalCost { get; set; }
    public SummaryDTO Summary { get; set; }
}

public class IngredientDTO
{
    public int IngredientId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } // Enum: Default, Optional, Excluded
    public decimal AdditionalCost { get; set; }
    //public bool IsSelected { get; set; }
}

public class OptionDTO
{
    public string Name { get; set; }
    public decimal CostPerApplication { get; set; }
}

public class AppliedOptionDTO
{
    public string Name { get; set; }
    public int MaxTimesApplicable { get; set; }
    public bool IsApplicable { get; set; }
    public decimal TotalCost { get; set; }
    public int TimesApplied { get; set; }
}

public class SummaryDTO
{
    public List<AppliedIngredientSummaryDTO> SelectedIngredients { get; set; }
    public List<AppliedOptionDTO> AppliedOptions { get; set; }
}

public class AppliedOptionSummaryDTO
{
    public string OptionName { get; set; }
    public int TimesApplied { get; set; }
}

public class AppliedIngredientSummaryDTO
{
    public int IngredientId { get; set; }
    public string IngredientName { get; set; }
}

public class CreateOrUpdatePizzaTemplateRequestDTO
{
    public List<IngredientRequestDTO> Ingredients { get; set; } // Список ингредиентов
    public List<AppliedOptionRequestDTO> AppliedOptions { get; set; } // Список примененных опций

    public IEnumerable<string> GetKeys()
    {
        return AppliedOptions.Select(o => o.OptionName);
    }
}

public class IngredientRequestDTO
{
    public int IngredientId { get; set; } // Уникальный идентификатор ингредиента
    public string Name { get; set; } // Название ингредиента
}

public class AppliedOptionRequestDTO
{
    public string OptionName { get; set; } // Уникальный идентификатор опции
    public int TimesApplied { get; set; } // Количество раз, примененное пользователем
}
