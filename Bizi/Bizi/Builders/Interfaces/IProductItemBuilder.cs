using Bizi.DAL.Product;
using Bizi.Models;

namespace Bizi.Builders.Interfaces
{
    public interface IProductItemBuilder
    {
        ProductItemEntity BuildProductEntity(ProductModel productModel);
    }
}
