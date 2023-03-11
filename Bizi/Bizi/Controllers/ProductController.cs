using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Bizi.Models;
using Bizi.Services.Interfaces;
using System.Linq;

namespace Bizi.Controllers
{
    public class ProductController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [FunctionName("create")]
        public async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "products")] ProductModel productModel,
            ILogger log)
        {
            if (productModel == null)
            {
                return new BadRequestObjectResult("Incoming productModel is null at products create endpoint.");
            }
            log.LogInformation($"Trying to create product {productModel?.Sku}.");

            try
            {
                var res = await _productService.CreateProduct(productModel);
                if (res != null)
                {
                    return new OkObjectResult($"Successfully created product with id {productModel.Sku}.");
                }
                return new ObjectResult($"Could not create product with id {productModel?.Sku}");
            }
            catch (Exception ex)
            {
                log.LogError($"Error when creating product with id {productModel.Sku}.", ex);
                throw;
            }
        }

        [FunctionName("list")]
        public IActionResult List(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "products/list")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var allProducts = _productService.GetAllProducts();
                if (allProducts != null && allProducts.Any())
                {
                    return new OkObjectResult(allProducts.Select(x => x.Id).ToList());
                }
                return new ObjectResult("No products found");
            }
            catch (Exception ex)
            {
                log.LogError($"Error when listing products.", ex);
                throw;
            }
        }
    }
}
