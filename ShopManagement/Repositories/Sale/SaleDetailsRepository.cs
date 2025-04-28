/******************************************************************************
 * Author:      Likhon
 * Created:     April 28, 2025
 * Description: Database connection and queries for SaleDetails table
 ******************************************************************************/

using Microsoft.Data.SqlClient;
using System.Data;
using ShopManagement.Interfaces.Sale;
using ShopManagement.Models;

namespace ShopManagement.Repositories.Sale
{
    public class SaleDetailsRepository : ISaleDetailsRepository
    {
        SqlConnection con = new SqlConnection(
            "Data Source=192.168.0.111;Initial Catalog=Likhon;User ID=developer;Password=123456;Trust Server Certificate=True");

        public string SaleDetailsPost(SaleDetails saleDetails)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[sale].[sprSaleDetailsCreate]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intSaleID", saleDetails.intSaleID);
                com.Parameters.AddWithValue("@intProductID", saleDetails.intProductID);
                com.Parameters.AddWithValue("@intQuantity", saleDetails.intQuantity);

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
        public DataSet SaleDetailsGet()
        {
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("[sale].[sprSaleDetailsRead]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intSaleDetailsID", null);

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
        public DataSet SaleDetailsGet(int id)
        {
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("[sale].[sprSaleDetailsRead]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intSaleDetailsID", id);

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
        public string SaleDetailsUpdate(SaleDetails saleDetails, int id)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[sale].[sprSaleDetailsUpdate]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intSaleDetailsID", id);
                com.Parameters.AddWithValue("@intSaleID", saleDetails.intSaleID);
                com.Parameters.AddWithValue("@intProductID", saleDetails.intProductID);
                com.Parameters.AddWithValue("@intQuantity", saleDetails.intQuantity);

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
        public string SaleDetailsDelete(int id)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[sale].[sprSaleDetailsDelete]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intSaleDetailsID", id);

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
