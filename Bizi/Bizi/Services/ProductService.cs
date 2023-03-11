using Azure;
using Azure.Data.Tables;
using Bizi.Builders.Interfaces;
using Bizi.DAL.Product;
using Bizi.Models;
using Bizi.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bizi.Services
{
    public class ProductService : IProductService
    {
        private readonly ITableClientFactory _tableClientFactory;
        private readonly TableClient _tableClient;
        private readonly IProductItemBuilder _productItemBuilder;

        public ProductService(ITableClientFactory tableClientFactory, 
            IProductItemBuilder productItemBuilder)
        {
            _tableClientFactory = tableClientFactory;
            _tableClient = _tableClientFactory.Create();
            _productItemBuilder = productItemBuilder;
        }

        public async Task<Response> CreateProduct(ProductModel productModel)
        {
            await _tableClient.CreateIfNotExistsAsync();
            var productEntity = _productItemBuilder.BuildProductEntity(productModel);
            if (GetProduct(productEntity) == null)
            {
                return _tableClient.AddEntity(productEntity);
            }
            return null;
        }

        public ProductItemEntity GetProduct(ProductItemEntity productEntity)
        {
            Pageable<ProductItemEntity> getProductQuery = _tableClient.Query<ProductItemEntity>(filter: $"RowKey eq '{productEntity.Id}'");
            return getProductQuery.Any() ? getProductQuery.FirstOrDefault() : null;
        }

        public List<ProductItemEntity> GetAllProducts()
        {
            Pageable<ProductItemEntity> getAllProductsQuery = _tableClient.Query<ProductItemEntity>();
            return getAllProductsQuery?.ToList();
        }
    }
}
