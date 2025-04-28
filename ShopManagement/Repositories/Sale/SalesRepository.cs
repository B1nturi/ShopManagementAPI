/******************************************************************************
 * Author:      Likhon
 * Created:     April 26, 2025
 * Description: Database connection and queries for Sales table
 ******************************************************************************/

using Microsoft.Data.SqlClient;
using ShopManagement.Interfaces.Sale;
using ShopManagement.Models;
using System.Data;

namespace ShopManagement.Repositories.Sale
{
    public class PurchasesRepository : ISalesRepository
    {
        SqlConnection con = new SqlConnection(
            "Data Source=192.168.0.111;Initial Catalog=Likhon;User ID=developer;Password=123456;Trust Server Certificate=True");

        public string SalesPost(Sales sales)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[sale].[sprSalesCreate]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intCustomerID", sales.intCustomerID);
                com.Parameters.AddWithValue("@intEmployeeID", sales.intEmployeeID);
                com.Parameters.AddWithValue("@strPaymentMethod", sales.strPaymentMethod);
                com.Parameters.AddWithValue("@strPaymentStatus", sales.strPaymentStatus);
                
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
        public DataSet SalesGet()
        {
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("[sale].[sprSalesRead]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intSaleID", null);

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
        public DataSet SalesGet(int id)
        {
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("[sale].[sprSalesRead]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intSaleID", id);
                
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
        public string SalesUpdate(Sales sales, int id)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[sale].[sprSalesUpdate]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intSupplierID", id);
                com.Parameters.AddWithValue("@intCustomerID", sales.intCustomerID);
                com.Parameters.AddWithValue("@intEmployeeID", sales.intEmployeeID);
                com.Parameters.AddWithValue("@strPaymentMethod", sales.strPaymentMethod);
                com.Parameters.AddWithValue("@strPaymentStatus", sales.strPaymentStatus);
                
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
        public string SalesDelete(int id)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[sale].[sprSalesDelete]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intSaleID", id);
                
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
