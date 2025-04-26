/******************************************************************************
 * Author:      Likhon
 * Created:     April 24, 2025
 * Description: Products Model
 ******************************************************************************/

namespace ShopManagement.Models
{
    public class Products
    {
        public int intProductID { get; set; }
        public string strProductName { get; set; }
        public string strDescription { get; set; }
        public int intCategoryID { get; set; }
        public decimal decCostPrice { get; set; }
        public decimal decPrice { get; set; }
        public int intSupplierID { get; set; }
        public int intCreatedBy { get; set; }
    }
}
