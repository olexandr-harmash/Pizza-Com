namespace PizzaCom.Domain.AggregatesModel;

 /// <summary>
    /// Represents the type of an ingredient in the pizza domain.
    /// </summary>
    public class IngredientType : Enumeration
    {
        /// <summary>
        /// Represents a meat ingredient.
        /// </summary>
        public static IngredientType Meat = new(1, nameof(Meat));

        /// <summary>
        /// Represents a vegetable ingredient.
        /// </summary>
        public static IngredientType Vegetable = new(2, nameof(Vegetable));

        /// <summary>
        /// Represents a dairy ingredient.
        /// </summary>
        public static IngredientType Dairy = new(3, nameof(Dairy));

        /// <summary>
        /// Represents a grain ingredient.
        /// </summary>
        public static IngredientType Grain = new(4, nameof(Grain));

        /// <summary>
        /// Represents a seafood ingredient.
        /// </summary>
        public static IngredientType Seafood = new(5, nameof(Seafood));

        public static IngredientType Herbs = new(6, nameof(Herbs));

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientType"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for the ingredient type.</param>
        /// <param name="name">The name of the ingredient type.</param>
        public IngredientType(int id, string name)
            : base(id, name)
        {
        }
    }