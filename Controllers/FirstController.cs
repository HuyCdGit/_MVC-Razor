using AppMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private ProductService _ProductService;

        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _ProductService = productService;
        }

        public void nothing()
        {
            _logger.LogInformation("Nothing Action");
            Response.Headers.Add("Hi","Hello");
        }

        public IActionResult Image()
        {
            string filePath = Path.Combine(Startup.ContentRootPath, "Files", "_TC_0022.JPG");
            var bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "image/jpg");

        }

        public IActionResult Productview(int? id)
        {
            var qr = _ProductService.Where(r => r.Id == id).FirstOrDefault();
            if(qr == null)
                return NotFound();
            //return View(qr);

            //this.ViewData["product"] = qr;
            return View(qr);
        }
    }
}