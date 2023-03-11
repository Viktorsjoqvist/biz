using Azure;
using Azure.Data.Tables;
using Bizi.DAL.Product;
using Bizi.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizi.Services.Interfaces
{
    public interface IProductService
    {
        Task<Response> CreateProduct(ProductModel productModel);
        List<ProductItemEntity> GetAllProducts();
    }
}
