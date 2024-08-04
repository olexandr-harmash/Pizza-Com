using PizzaCom.Infrastructure.Models;

namespace PizzaCom.Infrastructure.Repositories;

public class BlueprintRepository : IBlueprintRepository
{
    private readonly PizzaComContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public BlueprintRepository(PizzaComContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Blueprint b)
    {
        //TODO: auto mapper
        var blueprintEntity = new BlueprintEntity
        {
            Id = b.Id,
            Name = b.Name,
            BaseCost = b.BaseCost,
            Recipes = b.Recipes.Select(r => new RecipeEntity
            {
                Id = r.Id,
                Ingredient = new IngredientEntity
                {
                    Id = r.IngredientId,
                    Name = r.Name,
                    Cost = r.CostPer100g,
                    Type = r.IngredientType
                },
                Weight = r.Weight,
                Type = r.Type
            }).ToList()
        };

        _context.Blueprints.Add(blueprintEntity);
    }

    public async Task<Blueprint> GetAsync(int id)
    {
         // Получение сущности BlueprintEntity из контекста по ID
        var blueprintEntity = await _context.Blueprints
            .Include(b => b.Recipes)
                .ThenInclude(r => r.Ingredient) // Загрузка связанных ингредиентов
                    .ThenInclude(i => i.Type) // Загрузка типа ингредиента
            .Include(b => b.Recipes)
                .ThenInclude(r => r.Type) // Загрузка типа рецепта
            .FirstOrDefaultAsync(b => b.Id == id);

        if (blueprintEntity == null)
        {
            // Обработка случая, когда сущность не найдена
            return null; // Или выбросить исключение
        }

        // Преобразование BlueprintEntity в бизнес-объект Blueprint
        var blueprint = new Blueprint
        (
            blueprintEntity.Id,
            blueprintEntity.Name,
            blueprintEntity.BaseCost,
            blueprintEntity.Recipes.Select(r => new Recipe
            (
                r.Id,
                r.IngredientId,
                r.Ingredient.Cost,
                r.Weight,
                r.Ingredient.Name,
                r.Type,
                r.Ingredient.Type
            )).ToList()
        );

        return blueprint;
    }
}