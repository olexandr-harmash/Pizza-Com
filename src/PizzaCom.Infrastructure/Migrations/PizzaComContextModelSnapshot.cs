﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PizzaCom.Infrastructure;

#nullable disable

namespace PizzaCom.Infrastructure.Migrations
{
    [DbContext(typeof(PizzaComContext))]
    partial class PizzaComContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("PizzaCom.Domain.AggregatesModel.Boilerplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "blueprintseq");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("boilerplate", "pizza_com");
                });

            modelBuilder.Entity("PizzaCom.Domain.AggregatesModel.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "recipeseq");

                    b.Property<int>("BoilerplateId")
                        .HasColumnType("integer");

                    b.Property<int>("ComponentTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("IngredientId")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BoilerplateId");

                    b.HasIndex("ComponentTypeId");

                    b.HasIndex("IngredientId");

                    b.ToTable("component", "pizza_com");
                });

            modelBuilder.Entity("PizzaCom.Domain.AggregatesModel.ComponentType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("component_type", "pizza_com");
                });

            modelBuilder.Entity("PizzaCom.Domain.AggregatesModel.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "ingredientseq");

                    b.Property<decimal>("CostPer100g")
                        .HasColumnType("numeric");

                    b.Property<int>("IngredientTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("IngredientTypeId");

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

            modelBuilder.Entity("PizzaCom.Domain.AggregatesModel.Component", b =>
                {
                    b.HasOne("PizzaCom.Domain.AggregatesModel.Boilerplate", null)
                        .WithMany("Components")
                        .HasForeignKey("BoilerplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaCom.Domain.AggregatesModel.ComponentType", "ComponentType")
                        .WithMany()
                        .HasForeignKey("ComponentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaCom.Domain.AggregatesModel.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComponentType");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("PizzaCom.Domain.AggregatesModel.Ingredient", b =>
                {
                    b.HasOne("PizzaCom.Domain.AggregatesModel.IngredientType", "IngredientType")
                        .WithMany()
                        .HasForeignKey("IngredientTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IngredientType");
                });

            modelBuilder.Entity("PizzaCom.Domain.AggregatesModel.Boilerplate", b =>
                {
                    b.Navigation("Components");
                });
#pragma warning restore 612, 618
        }
    }
}
