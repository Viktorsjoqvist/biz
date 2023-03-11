using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure;
using Microsoft.Azure.Storage;
using Bizi.Models;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Bizi.Constants;
using Azure.Data.Tables;
using Bizi.Services.Interfaces;
using Azure.Data.Tables.Models;
using Bizi.DAL.Product;
using System.Collections.Generic;
using Azure;
using System.Collections.Concurrent;
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
            log.LogInformation($"Incoming productModel at create endpoint: {productModel}.");

            var res = await _productService.CreateProduct(productModel);
            if (res != null)
            {
                return new OkObjectResult($"Successfully created product with id {productModel.Sku}.");
            }
            return new ObjectResult($"Could not create product with id {productModel?.Sku}");
        }

        [FunctionName("list")]
        public IActionResult List(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "products/list")] HttpRequest req,
            ILogger log)
        {
            var allProducts = _productService.GetAllProducts();
            if (allProducts != null && allProducts.Any()) 
            {
                return new OkObjectResult(allProducts.Select(x => x.Id).ToList());
            }
            return new ObjectResult("No products found");
        }
    }
}
