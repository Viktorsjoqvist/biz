using Bizi.DAL.Product;
using Bizi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizi.Builders.Interfaces
{
    public interface IProductItemBuilder
    {
        ProductItemEntity BuildProductEntity(ProductModel productModel);
    }
}
