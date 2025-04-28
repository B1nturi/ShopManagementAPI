/******************************************************************************
 * Author:      Likhon
 * Created:     April 28, 2025
 * Description: Database connection and queries for Purchases table
 ******************************************************************************/

using Microsoft.Data.SqlClient;
using ShopManagement.Interfaces.Purchase;
using ShopManagement.Models;
using System.Data;

namespace ShopManagement.Repositories.Purchase
{
    public class PurchasesRepository : IPurchsesRepository
    {
        SqlConnection con = new SqlConnection(
            "Data Source=192.168.0.111;Initial Catalog=Likhon;User ID=developer;Password=123456;Trust Server Certificate=True");

        public string PurchasesPost(Purchases purchases)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[purchase].[sprPurchasesCreate]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intCustomerID", purchases.intSupplierID);
                com.Parameters.AddWithValue("@intEmployeeID", purchases.intEmployeeID);
                com.Parameters.AddWithValue("@strPaymentMethod", purchases.strPaymentMethod);
                com.Parameters.AddWithValue("@strPaymentStatus", purchases.strPaymentStatus);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet PurchasesGet()
        {
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("[purchase].[sprPurchasesRead]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intPurchaseID", null);

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return ds;
        }
        public DataSet PurchasesGet(int id)
        {
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("[purchase].[sprPurchasesRead]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intPurchaseID", id);
                
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return ds;
        }
        public string PurchasesUpdate(Purchases purchases, int id)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[purchase].[sprPurchasesUpdate]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intSupplierID", id);
                com.Parameters.AddWithValue("@intCustomerID", purchases.intSupplierID);
                com.Parameters.AddWithValue("@intEmployeeID", purchases.intEmployeeID);
                com.Parameters.AddWithValue("@strPaymentMethod", purchases.strPaymentMethod);
                com.Parameters.AddWithValue("@strPaymentStatus", purchases.strPaymentStatus);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public string PurchasesDelete(int id)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[purchase].[sprPurchasesDelete]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intPurchaseID", id);
                
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return msg;
        }
    }
}
