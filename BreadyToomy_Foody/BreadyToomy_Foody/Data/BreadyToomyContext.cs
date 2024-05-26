using Microsoft.EntityFrameworkCore;
using BreadyToomy_Foody.Models;

namespace BreadyToomy_Foody.Data
{
    public class BreadyToomyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeStep> RecipeSteps { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=breadytoomy.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductIngredient>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

        }

        public void SeedData()
        {
            // Insert sample data into Recipe table
            Recipes.AddRange(
                new Recipe { Difficulty = "easy", CookTime = 15, Archived = false },
                new Recipe { Difficulty = "medium", CookTime = 30, Archived = false },
                new Recipe { Difficulty = "hard", CookTime = 45, Archived = false }
            );

            // Insert sample data into RecipeStep table
            RecipeSteps.AddRange(
                new RecipeStep { RecipeId = 1, Index = 1, StepDetails = "Preheat the oven to 350 degrees F.", Archived = false },
                new RecipeStep { RecipeId = 1, Index = 2, StepDetails = "Mix flour and sugar in a bowl.", Archived = false },
                new RecipeStep { RecipeId = 2, Index = 1, StepDetails = "Boil water in a large pot.", Archived = false },
                new RecipeStep { RecipeId = 2, Index = 2, StepDetails = "Add pasta to the boiling water.", Archived = false },
                new RecipeStep { RecipeId = 3, Index = 1, StepDetails = "Chop vegetables into small pieces.", Archived = false },
                new RecipeStep { RecipeId = 3, Index = 2, StepDetails = "Stir-fry vegetables in a pan.", Archived = false }
            );

            // Insert sample data into Product table
            Products.AddRange(
                new Product { Name = "Spaghetti", RecipeId = 2, Type = "meal", Description = "Delicious spaghetti with tomato sauce", Price = 10, Archived = false },
                new Product { Name = "Salad", RecipeId = 3, Type = "meal", Description = "Fresh garden salad", Price = 7, Archived = false },
                new Product { Name = "Cake", RecipeId = 1, Type = "dessert", Description = "Chocolate cake", Price = 15, Archived = false }
            );

            // Insert sample data into Ingredient table
            Ingredients.AddRange(
                new Ingredient { Name = "Flour", Archived = false },
                new Ingredient { Name = "Sugar", Archived = false },
                new Ingredient { Name = "Tomato", Archived = false },
                new Ingredient { Name = "Lettuce", Archived = false },
                new Ingredient { Name = "Pasta", Archived = false },
                new Ingredient { Name = "Chocolate", Archived = false }
            );

            // Insert sample data into ProductIngredient table
            ProductIngredients.AddRange(
                new ProductIngredient { ProductId = 1, IngredientId = 5, Quantity = 2, Archived = false }, // Spaghetti with Pasta
                new ProductIngredient { ProductId = 1, IngredientId = 3, Quantity = 3, Archived = false }, // Spaghetti with Tomato
                new ProductIngredient { ProductId = 2, IngredientId = 4, Quantity = 1, Archived = false }, // Salad with Lettuce
                new ProductIngredient { ProductId = 3, IngredientId = 1, Quantity = 2, Archived = false }, // Cake with Flour
                new ProductIngredient { ProductId = 3, IngredientId = 2, Quantity = 1, Archived = false }, // Cake with Sugar
                new ProductIngredient { ProductId = 3, IngredientId = 6, Quantity = 1, Archived = false }  // Cake with Chocolate
            );

            // Insert sample data into Order table
            Orders.AddRange(
                new Order { Number = 1001, Type = "delivery", State = "submitted" },
                new Order { Number = 1002, Type = "pickup", State = "processed" },
                new Order { Number = 1003, Type = "delivery", State = "delivered" }
            );

            // Insert sample data into OrderProduct table
            OrderProducts.AddRange(
                new OrderProduct { OrderId = 1, ProductId = 1, Quantity = 2 }, // Order 1 with 2 Spaghetti
                new OrderProduct { OrderId = 1, ProductId = 3, Quantity = 1 }, // Order 1 with 1 Cake
                new OrderProduct { OrderId = 2, ProductId = 2, Quantity = 3 }, // Order 2 with 3 Salad
                new OrderProduct { OrderId = 3, ProductId = 1, Quantity = 1 }  // Order 3 with 1 Spaghetti
            );

            SaveChanges();
        }
    }
}
