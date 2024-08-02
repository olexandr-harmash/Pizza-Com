using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaCom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pizza_com");

            migrationBuilder.CreateSequence(
                name: "blueprintseq",
                schema: "pizza_com",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "ingredientseq",
                schema: "pizza_com",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "recipeseq",
                schema: "pizza_com",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "blueprint",
                schema: "pizza_com",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    BaseCost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blueprint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ingredient_type",
                schema: "pizza_com",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "recipe_type",
                schema: "pizza_com",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ingredient",
                schema: "pizza_com",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    _ingredientTypeId = table.Column<int>(type: "integer", nullable: false),
                    RecipeTypeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ingredient_ingredient_type__ingredientTypeId",
                        column: x => x._ingredientTypeId,
                        principalSchema: "pizza_com",
                        principalTable: "ingredient_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ingredient_recipe_type_RecipeTypeId",
                        column: x => x.RecipeTypeId,
                        principalSchema: "pizza_com",
                        principalTable: "recipe_type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "recipe",
                schema: "pizza_com",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    _recipeTypeId = table.Column<int>(type: "integer", nullable: false),
                    _ingredientId = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    _blueprintId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recipe_blueprint__blueprintId",
                        column: x => x._blueprintId,
                        principalSchema: "pizza_com",
                        principalTable: "blueprint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recipe_ingredient__ingredientId",
                        column: x => x._ingredientId,
                        principalSchema: "pizza_com",
                        principalTable: "ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recipe_recipe_type__recipeTypeId",
                        column: x => x._recipeTypeId,
                        principalSchema: "pizza_com",
                        principalTable: "recipe_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_RecipeTypeId",
                schema: "pizza_com",
                table: "ingredient",
                column: "RecipeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ingredient__ingredientTypeId",
                schema: "pizza_com",
                table: "ingredient",
                column: "_ingredientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_recipe__blueprintId",
                schema: "pizza_com",
                table: "recipe",
                column: "_blueprintId");

            migrationBuilder.CreateIndex(
                name: "IX_recipe__ingredientId",
                schema: "pizza_com",
                table: "recipe",
                column: "_ingredientId");

            migrationBuilder.CreateIndex(
                name: "IX_recipe__recipeTypeId",
                schema: "pizza_com",
                table: "recipe",
                column: "_recipeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recipe",
                schema: "pizza_com");

            migrationBuilder.DropTable(
                name: "blueprint",
                schema: "pizza_com");

            migrationBuilder.DropTable(
                name: "ingredient",
                schema: "pizza_com");

            migrationBuilder.DropTable(
                name: "ingredient_type",
                schema: "pizza_com");

            migrationBuilder.DropTable(
                name: "recipe_type",
                schema: "pizza_com");

            migrationBuilder.DropSequence(
                name: "blueprintseq",
                schema: "pizza_com");

            migrationBuilder.DropSequence(
                name: "ingredientseq",
                schema: "pizza_com");

            migrationBuilder.DropSequence(
                name: "recipeseq",
                schema: "pizza_com");
        }
    }
}
