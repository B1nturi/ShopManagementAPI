/******************************************************************************
 * Author:      Likhon
 * Created:     April 26, 2025
 * Description: Sales Model
 ******************************************************************************/

namespace ShopManagement.Models
{
    public class Sales
    {
        public int intSaleId { get; set; }
        public int intCustomerID { get; set; }
        public int intEmployeeID { get; set; }
        public string? dtrSaleDate { get; set; }
        public decimal decTotalAmount { get; set; }
        public string? strPaymentMethod { get; set; }
        public string? strPaymentStatus { get; set; }
    }
}
