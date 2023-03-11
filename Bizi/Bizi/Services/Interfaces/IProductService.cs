using Azure;
using Bizi.DAL.Product;
using Bizi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bizi.Services.Interfaces
{
    public interface IProductService
    {
        Task<Response> CreateProduct(ProductModel productModel);
        List<ProductItemEntity> GetAllProducts();
    }
}
