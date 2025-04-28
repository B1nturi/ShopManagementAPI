/******************************************************************************
 * Author:      Likhon
 * Created:     April 26, 2025
 * Description: SaleDetails Repository Interface
 ******************************************************************************/
using ShopManagement.Models;
using System.Data;

namespace ShopManagement.Interfaces.Sale
{
    public interface ISalesRepository
    {
        public string SalesPost(Sales sales);
        public DataSet SalesGet();
        public DataSet SalesGet(int id);
        public string SalesUpdate(Sales sales, int id);
        public string SalesDelete(int id);
    }
}
