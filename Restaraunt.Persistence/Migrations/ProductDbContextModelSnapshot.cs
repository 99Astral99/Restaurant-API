﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Restaraunt.Persistence;

#nullable disable

namespace Restaraunt.Persistence.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    partial class ProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Restaraunt.Domain.Burger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(700)
                        .HasColumnType("character varying(700)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Weight")
                        .HasMaxLength(1000)
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Burgers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Chicken lovers will appreciate the novelty Caesar King! Juicy crispy chicken nuggets, fresh tomato and lettuce are seasoned with Caesar sauce and served on a browned sesame bun.",
                            Name = "Hamburger",
                            Price = 1.3300000000000001,
                            Weight = 105
                        },
                        new
                        {
                            Id = 2,
                            Description = "This is a spicy version of juicy Grand Cheese — with a burning sauce instead of ketchup! Homemade beef steak with the addition of juicy chicken — in your favorite combination with Cheddar cheese, pickled cucumbers, onions, mustard and spicy tomato sauce on a browned sesame bun!",
                            Name = "Spicy Grand Cheese",
                            Price = 2.3199999999999998,
                            Weight = 171
                        },
                        new
                        {
                            Id = 3,
                            Description = "Whopper - is delicious 100% beef cooked on fire with juicy tomatoes, fresh chopped lettuce, thick mayonnaise, crispy pickled cucumbers and fresh onions on a tender sesame bun.",
                            Name = "Triple Whopper",
                            Price = 4.0,
                            Weight = 426
                        });
                });

            modelBuilder.Entity("Restaraunt.Domain.Entities.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(700)
                        .HasColumnType("character varying(700)");

                    b.Property<bool>("IsCarbonated")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Size")
                        .HasMaxLength(1500)
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Drinks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A fragrant coffee drink with a delicate milk foam.",
                            IsCarbonated = false,
                            Name = "Capuccino",
                            Price = 1.75,
                            Size = 100
                        },
                        new
                        {
                            Id = 2,
                            Description = "Natural freshly brewed coffee with ice cream.",
                            IsCarbonated = false,
                            Name = "Coffee glace",
                            Price = 1.55,
                            Size = 100
                        },
                        new
                        {
                            Id = 3,
                            Description = "A reall fresh beer.",
                            IsCarbonated = true,
                            Name = "Beer",
                            Price = 3.0,
                            Size = 500
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
