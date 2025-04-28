/******************************************************************************
 * Author:      Likhon
 * Created:     April 28, 2025
 * Description: SaleDetails Model
 ******************************************************************************/

namespace ShopManagement.Models
{
    public class SaleDetails
    {
        public int intSaleDetailsID { get; set; }
        public int intSaleID { get; set; }
        public int intProductID { get; set; }
        public decimal intQuantity { get; set; }
        public decimal decUnitPrice { get; set; }
    }
}