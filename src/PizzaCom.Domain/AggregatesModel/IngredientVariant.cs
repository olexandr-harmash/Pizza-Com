public class IngredientVariant : Enumeration
{
    /// <summary>
    /// Represents Pepperoni ingredient.
    /// </summary>
    public static IngredientVariant Pepperoni = new(1, nameof(Pepperoni));

    /// <summary>
    /// Represents Sausage ingredient.
    /// </summary>
    public static IngredientVariant Sausage = new(2, nameof(Sausage));

    /// <summary>
    /// Represents Chicken ingredient.
    /// </summary>
    public static IngredientVariant Chicken = new(3, nameof(Chicken));

    /// <summary>
    /// Represents Bacon ingredient.
    /// </summary>
    public static IngredientVariant Bacon = new(4, nameof(Bacon));

    /// <summary>
    /// Represents Tomato ingredient.
    /// </summary>
    public static IngredientVariant Tomato = new(5, nameof(Tomato));

    /// <summary>
    /// Represents Onion ingredient.
    /// </summary>
    public static IngredientVariant Onion = new(6, nameof(Onion));

    /// <summary>
    /// Represents Bell Pepper ingredient.
    /// </summary>
    public static IngredientVariant BellPepper = new(7, nameof(BellPepper));

    /// <summary>
    /// Represents Olives ingredient.
    /// </summary>
    public static IngredientVariant Olives = new(8, nameof(Olives));

    /// <summary>
    /// Represents Mushrooms ingredient.
    /// </summary>
    public static IngredientVariant Mushrooms = new(9, nameof(Mushrooms));

    /// <summary>
    /// Represents Mozzarella ingredient.
    /// </summary>
    public static IngredientVariant Mozzarella = new(10, nameof(Mozzarella));

    /// <summary>
    /// Represents Cheddar ingredient.
    /// </summary>
    public static IngredientVariant Cheddar = new(11, nameof(Cheddar));

    /// <summary>
    /// Represents Gouda ingredient.
    /// </summary>
    public static IngredientVariant Gouda = new(12, nameof(Gouda));

    /// <summary>
    /// Represents Parmesan ingredient.
    /// </summary>
    public static IngredientVariant Parmesan = new(13, nameof(Parmesan));

    /// <summary>
    /// Represents Feta ingredient.
    /// </summary>
    public static IngredientVariant Feta = new(14, nameof(Feta));

    /// <summary>
    /// Represents Gluten Crust ingredient.
    /// </summary>
    public static IngredientVariant GlutenCrust = new(15, nameof(GlutenCrust));

    /// <summary>
    /// Represents Gluten-Free Crust ingredient.
    /// </summary>
    public static IngredientVariant GlutenFreeCrust = new(16, nameof(GlutenFreeCrust));

    /// <summary>
    /// Represents Whole Wheat Crust ingredient.
    /// </summary>
    public static IngredientVariant WholeWheatCrust = new(17, nameof(WholeWheatCrust));

    /// <summary>
    /// Represents Thin Crust ingredient.
    /// </summary>
    public static IngredientVariant ThinCrust = new(18, nameof(ThinCrust));

    /// <summary>
    /// Represents Shrimp ingredient.
    /// </summary>
    public static IngredientVariant Shrimp = new(19, nameof(Shrimp));

    /// <summary>
    /// Represents Anchovies ingredient.
    /// </summary>
    public static IngredientVariant Anchovies = new(20, nameof(Anchovies));

    /// <summary>
    /// Represents Crab ingredient.
    /// </summary>
    public static IngredientVariant Crab = new(21, nameof(Crab));

    /// <summary>
    /// Represents Clams ingredient.
    /// </summary>
    public static IngredientVariant Clams = new(22, nameof(Clams));

    public static IngredientVariant Basil = new(23, nameof(Basil));

    public static IngredientVariant Corn = new(24, nameof(Corn));

    /// <summary>
    /// Initializes a new instance of the <see cref="IngredientVariant"/> class.
    /// </summary>
    /// <param name="id">The unique identifier for the ingredient.</param>
    /// <param name="name">The name of the ingredient.</param>
    public IngredientVariant(int id, string name)
        : base(id, name)
    {
    }
}