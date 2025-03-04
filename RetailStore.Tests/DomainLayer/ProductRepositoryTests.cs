using RetailStore.DomainLayer.Repositories.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using RetailStore.DomainLayer.Core;

namespace RetailStore.Tests.DomainLayer
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private RetailStoreDbContext _dbContext;
        private DbContextOptions<RetailStoreDbContext> _dbContextOptions;
        private ProductRepository _productRepository;

        [SetUp]
        public void Setup()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Testing.json", optional: false, reloadOnChange: true)
                .Build();

            _dbContextOptions = new DbContextOptionsBuilder<RetailStoreDbContext>().UseSqlServer(configuration.GetConnectionString("DbConnectionString")).Options;

            _dbContext = new RetailStoreDbContext(_dbContextOptions);

            _productRepository = new ProductRepository(_dbContext);
        }

        [Test]
        public void Test_GetProducts()
        {
            var result = _productRepository.GetProducts();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Dispose();
        }
    }
}