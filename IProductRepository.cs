using System;
using System.Collections.Generic;
using TrueCoders_Final_Project_MVC.Models;

namespace TrueCoders_Final_Project_MVC
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProduct(int id);
        public void UpdateProduct(Product prod);
    }
}
