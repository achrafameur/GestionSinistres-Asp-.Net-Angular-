using Insurise.Core.Entities.Production.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace Insurise.Tests
{
    public class ProductControllerTests
    {
        public ProductControllerTests()
        {
            InitTest();
        }
        //private readonly AppWebApplicationFactory<TestStartup> _factory;
        //private readonly HttpClient _client;
        //private readonly IProductRepository _productRepository;
        private Product _product;


        private Product CreateEntity()
        {
            var product = new Product("test", "test", DateTime.Now, DateTime.Now.AddYears(1), 0,1, "X1", "", "");
            return product;    
        }
        private void InitTest()
        {
            _product = CreateEntity();
        }
        [Fact]
        public void CreatePackage_tests()
        {

        }
    }
}
