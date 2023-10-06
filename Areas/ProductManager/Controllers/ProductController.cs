using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers
{
    [Area("ProductManager")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        public IActionResult Index1()
        {
            var product = _productService.OrderBy(r => r.Name).ToList();
            return View(product);
        }
    }
}