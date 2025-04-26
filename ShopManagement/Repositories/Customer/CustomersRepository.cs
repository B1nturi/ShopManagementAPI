/******************************************************************************
 * Author:      Likhon
 * Created:     April 25, 2025
 * Description: Database connection and queries for Suppliers table
 ******************************************************************************/

using Microsoft.Data.SqlClient;
using System.Data;
using ShopManagement.Models;
using ShopManagement.Interfaces.Customer;

namespace ShopManagement.Repositories.Customer
{
    public class CustomersRepository : ICustomersRepository
    {
        SqlConnection con = new SqlConnection(
           "Data Source=192.168.0.111;Initial Catalog=Likhon;User ID=developer;Password=123456;Trust Server Certificate=True");

        public string CustomersPost(Customers customers)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[customer].[sprCustomersCreate]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@strCustomerName", customers.strCustomerName);
                com.Parameters.AddWithValue("@strPhone", customers.strPhone);
                com.Parameters.AddWithValue("@strEmail", customers.strEmail);
                com.Parameters.AddWithValue("@strAddress", customers.strAddress);

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

        public DataSet CustomersGet()
        {
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("[customer].[sprCustomersRead]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intCustomerID", null);

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
        
        public DataSet CustomersGet(int id)
        {
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("[customer].[sprCustomersRead]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intCustomerID", id);

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

        public string CustomersUpdate(Customers customers, int id)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[custome].[sprCustomersUpdate]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intCustomerID", id);
                com.Parameters.AddWithValue("@strCustomerName", customers.strCustomerName);
                com.Parameters.AddWithValue("@strPhone", customers.strPhone);
                com.Parameters.AddWithValue("@strEmail", customers.strEmail);
                com.Parameters.AddWithValue("@strAddress", customers.strAddress);

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

        public string CustomersDelete(int id)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[customer].[sprCustomersDelete]", con);
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
