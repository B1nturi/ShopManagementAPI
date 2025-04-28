/******************************************************************************
 * Author:      Likhon
 * Created:     April 28, 2025
 * Description: Sales Repository Interface
 ******************************************************************************/

using System.Data;
using ShopManagement.Models;

namespace ShopManagement.Interfaces.Sale
{
    public interface ISaleDetailsRepository
    {
        public string SaleDetailsPost(SaleDetails saleDetails);
        public DataSet SaleDetailsGet();
        public DataSet SaleDetailsGet(int id);
        public string SaleDetailsUpdate(SaleDetails saleDetails, int id);
        public string SaleDetailsDelete(int id);
    }
}
