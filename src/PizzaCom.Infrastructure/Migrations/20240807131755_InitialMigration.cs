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
                name: "boilerplate",
                schema: "pizza_com",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boilerplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "component_type",
                schema: "pizza_com",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_component_type", x => x.Id);
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
                name: "ingredient",
                schema: "pizza_com",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IngredientTypeId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CostPer100g = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ingredient_ingredient_type_IngredientTypeId",
                        column: x => x.IngredientTypeId,
                        principalSchema: "pizza_com",
                        principalTable: "ingredient_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "component",
                schema: "pizza_com",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    BoilerplateId = table.Column<int>(type: "integer", nullable: false),
                    ComponentTypeId = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_component", x => x.Id);
                    table.ForeignKey(
                        name: "FK_component_boilerplate_BoilerplateId",
                        column: x => x.BoilerplateId,
                        principalSchema: "pizza_com",
                        principalTable: "boilerplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_component_component_type_ComponentTypeId",
                        column: x => x.ComponentTypeId,
                        principalSchema: "pizza_com",
                        principalTable: "component_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_component_ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "pizza_com",
                        principalTable: "ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_component_BoilerplateId",
                schema: "pizza_com",
                table: "component",
                column: "BoilerplateId");

            migrationBuilder.CreateIndex(
                name: "IX_component_ComponentTypeId",
                schema: "pizza_com",
                table: "component",
                column: "ComponentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_component_IngredientId",
                schema: "pizza_com",
                table: "component",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_IngredientTypeId",
                schema: "pizza_com",
                table: "ingredient",
                column: "IngredientTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "component",
                schema: "pizza_com");

            migrationBuilder.DropTable(
                name: "boilerplate",
                schema: "pizza_com");

            migrationBuilder.DropTable(
                name: "component_type",
                schema: "pizza_com");

            migrationBuilder.DropTable(
                name: "ingredient",
                schema: "pizza_com");

            migrationBuilder.DropTable(
                name: "ingredient_type",
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
