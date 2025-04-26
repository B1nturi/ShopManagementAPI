/******************************************************************************
 * Author:      Likhon
 * Created:     April 26, 2025
 * Description: Products Repository Interface
 ******************************************************************************/

using ShopManagement.Models;
using System.Data;

namespace ShopManagement.Interfaces.Product
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
