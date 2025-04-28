/******************************************************************************
 * Author:      Likhon
 * Created:     April 28, 2025
 * Description: Purchases Repository Interface
 ******************************************************************************/

using ShopManagement.Models;
using System.Data;

namespace ShopManagement.Interfaces.Purchase
{
    public interface IPurchsesRepository
    {
        public string PurchasesPost(Purchases purchases);
        public DataSet PurchasesGet();
        public DataSet PurchasesGet(int id);
        public string PurchasesUpdate(Purchases purchases, int id);
        public string PurchasesDelete(int id);
    }
}
