# **Документация Домена**

## **Содержание**

- Сущности
  - Ingredient
  - Blueprint
  - Recipe
- Типы данных
  - IngredientType
  - RecipeType

## **Сущности**

### **Ingredient**

**Описание:  
**Представляет ингредиент в домене пиццы.

**Свойства:**

- Name (string): Название ингредиента.
- Cost (decimal): Стоимость ингредиента.
- Type (IngredientType): Тип ингредиента (например, мясо, овощи).

**Методы:**

Конструктор:  
csharp  
Copy code  
public Ingredient(string name, decimal cost, IngredientType type)

- **Параметры:**
  - name (string): Название ингредиента.
  - cost (decimal): Стоимость ингредиента.
  - type (IngredientType): Тип ингредиента.
- **Исключения:**
  - ArgumentNullException: Если name или type равны null.
  - ArgumentOutOfRangeException: Если cost меньше нуля.

### **Blueprint**

**Описание:  
**Представляет шаблон пиццы, который включает рецепт и базовую стоимость.

**Свойства:**

- Name (string): Название шаблона пиццы.
- BaseCost (decimal): Базовая стоимость пиццы.
- Recipe (IReadOnlyCollection&lt;Recipe&gt;): Рецепт пиццы.
- Ingredients (IReadOnlyCollection&lt;Recipe&gt;): Ингредиенты, которые являются базовыми.

**Методы:**

Конструктор:  
csharp  
Copy code  
public Blueprint(string name, decimal baseCost, List&lt;Recipe&gt; recipe)

- **Параметры:**
  - name (string): Название шаблона пиццы.
  - baseCost (decimal): Базовая стоимость пиццы.
  - recipe (List&lt;Recipe&gt;): Рецепт пиццы.
- **Исключения:**
  - ArgumentNullException: Если name или recipe равны null.
- AddIngredient(Recipe ingredient) **Параметры:**
  - ingredient (Recipe): Ингредиент для добавления.
- **Исключения:**
  - ArgumentException: Если ингредиент не является частью рецепта.
- ChangeIngredientWeight(Recipe ingredient, int weight) **Параметры:**
  - ingredient (Recipe): Ингредиент для изменения веса.
  - weight (int): Новый вес.
- **Исключения:**
  - ArgumentException: Если weight меньше нуля или больше ста.

### **Recipe**

**Описание:  
**Представляет рецепт, который включает ингредиент и его вес в пицце.

**Свойства:**

- Ingredient (Ingredient): Ингредиент рецепта.
- Weight (int): Вес ингредиента в рецепте.
- Type (RecipeType): Тип записи рецепта.

**Методы:**

Конструктор:  
csharp  
Copy code  
public Recipe(Ingredient ingredient, int weight, RecipeType type)

- **Параметры:**
  - ingredient (Ingredient): Ингредиент рецепта.
  - weight (int): Вес ингредиента.
  - type (RecipeType): Тип записи рецепта.
- **Исключения:**
  - ArgumentNullException: Если ingredient или type равны null.
  - ArgumentOutOfRangeException: Если weight меньше нуля или больше ста.

## **Типы данных**

### **IngredientType**

**Описание:  
**Представляет тип ингредиента.

**Типы:**

- Base: Базовый ингредиент, который всегда включен в пиццу.
- Optional: Опциональный ингредиент, который может быть добавлен в пиццу.
- Excludable: Ингредиент, который может быть исключен из пиццы.

### **RecipeType**

**Описание:  
**Представляет тип записи в рецепте.

**Типы:**

- Base: Базовый тип рецепта.
- Optional: Опциональный тип рецепта.
- Excludable: Исключаемый тип рецепта.