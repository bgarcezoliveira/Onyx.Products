using System.Data.Common;
using Bogus;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Onyx.Products.Infrastructure.DbContexts;
using Onyx.Products.Infrastructure.Entities;
using Onyx.Products.Shared.Enums;

namespace Onyx.Products.IntegrationTests
{
    public class SharedDatabaseFixture : IDisposable
    {
        private static readonly object _lock = new object();
        private static bool _databaseInitialized;
        private string dbName = "TestDatabase.db";

        public SharedDatabaseFixture()
        {
            Connection = new SqliteConnection($"Filename={dbName}");
            Seed();
            Connection.Open();
        }

        public DbConnection Connection
        {
            get;
        }

        public ProductsDbContext CreateContext(DbTransaction? transaction = null)
        {
            var context = new ProductsDbContext(new DbContextOptionsBuilder<ProductsDbContext>().UseSqlite(Connection).Options);
            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }
            return context;
        }

        private void Seed()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                        SeedData(context);
                    }
                    _databaseInitialized = true;
                }
            }
        }

        private void SeedData(ProductsDbContext context)
        {
            var fakeProducts = new Faker<Product>()
                .RuleFor(o => o.Name, f => "Fake Product")
                .RuleFor(o => o.Description, f => "Fake Description")
                .RuleFor(o => o.Id, f => Guid.NewGuid())
                .RuleFor(o => o.Price, f => f.Random.Decimal(1, 50))
                .RuleFor(o => o.Colour, f => f.Random.Enum<ColourEnum>())
                .RuleFor(o => o.Category, f => f.Random.Enum<CategoryEnum>());
            var products = fakeProducts.Generate(10);
            context.AddRange(products);
            context.SaveChanges();
        }
        public void Dispose() => Connection.Dispose();
    }
}

