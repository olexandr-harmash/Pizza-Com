﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PizzaCom.Infrastructure;

#nullable disable

namespace PizzaCom.Infrastructure.Migrations
{
    [DbContext(typeof(PizzaComContext))]
    [Migration("20240730104335_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("pizza_com")
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("blueprintseq")
                .IncrementsBy(10);

            modelBuilder.HasSequence("ingredientseq")
                .IncrementsBy(10);

            modelBuilder.HasSequence("recipeseq")
                .IncrementsBy(10);

            modelBuilder.Entity("PizzaCom.Domain.AggregatesModel.Blueprint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "blueprintseq");

                    b.Property<decimal>("BaseCost")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("blueprint", "pizza_com");
                });

            modelBuilder.Entity("PizzaCom.Domain.AggregatesModel.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "ingredientseq");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("_ingredientTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("_ingredientTypeId");

                    b.ToTable("ingredient", "pizza_com");
                });

            modelBuilder.Entity("PizzaCom.Domain.AggregatesModel.IngredientType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("ingredient_type", "pizza_com");
                });

            modelBuilder.Entity("PizzaCom.Domain.AggregatesModel.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "recipeseq");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.Property<int>("_blueprintId")
                        .HasColumnType("integer");

                    b.Property<int>("_ingredientId")
                        .HasColumnType("integer");

                    b.Property<int>("_recipeTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("_blueprintId");

                    b.HasIndex("_ingredientId");

                    b.HasIndex("_recipeTypeId");

                    b.ToTable("recipe", "pizza_com");
                });

            modelBuilder.Entity("PizzaCom.Domain.AggregatesModel.RecipeType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("recipe_type", "pizza_com");
                });

            modelBuilder.Entity("PizzaCom.Domain.AggregatesModel.Ingredient", b =>
                {
                    b.HasOne("PizzaCom.Domain.AggregatesModel.IngredientType", null)
                        .WithMany()
                        .HasForeignKey("_ingredientTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaCom.Domain.AggregatesModel.Recipe", b =>
                {
                    b.HasOne("PizzaCom.Domain.AggregatesModel.Blueprint", "_blueprint")
                        .WithMany("Recipe")
                        .HasForeignKey("_blueprintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaCom.Domain.AggregatesModel.Ingredient", "Ingredient")
                        .WithMany("_recipe")
                        .HasForeignKey("_ingredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaCom.Domain.AggregatesModel.RecipeType", null)
                        .WithMany()
                        .HasForeignKey("_recipeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("_blueprint");
                });

            modelBuilder.Entity("PizzaCom.Domain.AggregatesModel.Blueprint", b =>
                {
                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("PizzaCom.Domain.AggregatesModel.Ingredient", b =>
                {
                    b.Navigation("_recipe");
                });
#pragma warning restore 612, 618
        }
    }
}