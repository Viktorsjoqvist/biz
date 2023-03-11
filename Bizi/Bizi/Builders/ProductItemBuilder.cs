using Bizi.Builders.Interfaces;
using Bizi.DAL.Product;
using Bizi.Models;

namespace Bizi.Builders
{
    public class ProductItemBuilder : IProductItemBuilder
    {
        public ProductItemBuilder() { }

        public ProductItemEntity BuildProductEntity(ProductModel productModel)
        {
            return new ProductItemEntity(productModel.Category, productModel.Sku)
            {
                Category = productModel.Category,
                Id = productModel.Sku,
                Quantity = productModel.Quantity,
                Title = productModel.Name
            };
        }
    }
}
