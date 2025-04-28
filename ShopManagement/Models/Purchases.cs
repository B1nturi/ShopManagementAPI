/******************************************************************************
 * Author:      Likhon
 * Created:     April 28, 2025
 * Description: Purchases Model
 ******************************************************************************/

namespace ShopManagement.Models
{
    public class Purchases
    {
      public int intPurchaseID { get; set; }
      public int intSupplierID { get; set; }
      public int intEmployeeID { get; set; }
      public string? dtrPurchaseDate { get; set; }
      public decimal decTotalCost { get; set; }
      public string? strPaymentMethod { get; set; }
      public string? strPaymentStatus { get; set; }
    }
}
