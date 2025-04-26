using ShopManagement.Models;
using System.Data;

namespace ShopManagement.Interfaces
{
    public interface IProductsRepository
    {
        public string ProductsPost(Products products);
        public DataSet ProductsGet();
        public DataSet ProductsGet(int id);
        public string ProductsUpdate(Products products, int id);
        public string ProductsDelete(int id);
    }
}
