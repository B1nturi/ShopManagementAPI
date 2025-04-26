/******************************************************************************
 * Author:      Likhon
 * Created:     April 24, 2025
 * Description: Database connection and queries for Suppliers table
 ******************************************************************************/

using Microsoft.Data.SqlClient;
using System.Data;
using ShopManagement.Models;
using ShopManagement.Interfaces;

namespace ShopManagement.Repositories.Supplier
{
    public class SuppliersRepository : ISuppliersRepository
    {
        SqlConnection con = new SqlConnection(
           "Data Source=192.168.0.111;Initial Catalog=Likhon;User ID=developer;Password=123456;Trust Server Certificate=True");
        public string SuppliersPost(Suppliers suppliers)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[supply].[sprSuppliersCreate]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@strSupplierName", suppliers.strSupplierName);
                com.Parameters.AddWithValue("@strContactName", suppliers.strContactName);
                com.Parameters.AddWithValue("@strPhone", suppliers.strPhone);
                com.Parameters.AddWithValue("@strAddress", suppliers.strAddress);

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

        public DataSet SuppliersGet()
        {
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("[supply].[sprSuppliersRead]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intSupplierID", null);

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }

        public DataSet SuppliersGet(int id)
        {
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("[supply].[sprSuppliersRead]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intSupplierID", id);

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }

        public string SuppliersUpdate(Suppliers suppliers, int id)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[supply].[sprSuppliersUpdate]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intSupplierID", id);
                com.Parameters.AddWithValue("@strSupplierName", suppliers.strSupplierName);
                com.Parameters.AddWithValue("@strContactName", suppliers.strContactName);
                com.Parameters.AddWithValue("@strPhone", suppliers.strPhone);
                com.Parameters.AddWithValue("@strAddress", suppliers.strAddress);

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

        public string SuppliersDelete(int id)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[supply].[sprSuppliersDelete]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intSupplierID", id);

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
