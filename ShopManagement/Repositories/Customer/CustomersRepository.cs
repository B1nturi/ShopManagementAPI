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
                SqlCommand cmd = new SqlCommand("[customer].[sprCustomersCreate]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@strCustomerName", customers.strCustomerName);
                cmd.Parameters.AddWithValue("@strPhone", customers.strPhone);
                cmd.Parameters.AddWithValue("@strEmail", customers.strEmail);
                cmd.Parameters.AddWithValue("@strAddress", customers.strAddress);
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
                SqlCommand com = new SqlCommand("[customers].[sprCustomersRead]", con);
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
        
        public DataSet CustomersGet(int id)
        {
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("[customers].[sprCustomersRead]", con);
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

        public string CustomersUpdate(Customers customers, int id)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("[customer].[sprCustomersUpdate]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intCustomerID", id);
                cmd.Parameters.AddWithValue("@strCustomerName", customers.strCustomerName);
                cmd.Parameters.AddWithValue("@strPhone", customers.strPhone);
                cmd.Parameters.AddWithValue("@strEmail", customers.strEmail);
                cmd.Parameters.AddWithValue("@strAddress", customers.strAddress);
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
                SqlCommand com = new SqlCommand("[customers].[sprCustomersDelete]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intSupplierID", id);
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
