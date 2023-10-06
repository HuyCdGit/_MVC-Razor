using AppMVC.Models;
using AppMVC.Services;

namespace AppMVC.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[] {
                new ProductModel(){ Id = 1 ,Name = "iphone 1", Prices = 1000},
                new ProductModel(){ Id = 2, Name = "iphone 2", Prices = 2000},
                new ProductModel(){ Id = 3, Name = "iphone 3", Prices = 3000},
            });
        }
    }
}