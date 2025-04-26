/******************************************************************************
 * Author:      Likhon
 * Created:     April 25, 2025
 * Description: Customers interface
 ******************************************************************************/

using ShopManagement.Models;
using System.Data;

namespace ShopManagement.Interfaces.Customer
{
    public interface ICustomersRepository
    {
        public string CustomersPost(Customers customers);
        public DataSet CustomersGet();
        public DataSet CustomersGet(int id);
        public string CustomersUpdate(Customers customers, int id);
        public string CustomersDelete(int id);
    }
}
