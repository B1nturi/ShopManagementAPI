/******************************************************************************
 * Author:      Likhon
 * Created:     April 24, 2025
 * Description: Database connection and queries for Products table
 ******************************************************************************/

using Microsoft.Data.SqlClient;
using System.Data;
using ShopManagement.Models;
using ShopManagement.Interfaces;

namespace ShopManagement.Repositories.Product
{
    public class ProductsRepository : IProductsRepository
    {
        SqlConnection con = new SqlConnection(
           "Data Source=192.168.0.111;Initial Catalog=Likhon;User ID=developer;Password=123456;Trust Server Certificate=True");

        public string ProductsPost(Products products)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[product].[sprProductsCreate]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@strProductName", products.strProductName);
                com.Parameters.AddWithValue("@strDescription", products.strDescription);
                com.Parameters.AddWithValue("@intCategoryID", products.intCategoryID);
                com.Parameters.AddWithValue("@decCostPrice", products.decCostPrice);
                com.Parameters.AddWithValue("@decPrice", products.decPrice);
                com.Parameters.AddWithValue("@intSupplierID", products.intSupplierID);
                com.Parameters.AddWithValue("@intCreatedBy", products.intCreatedBy);

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

        public DataSet ProductsGet()
        {
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("[product].[sprProductsRead]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intProductID", null);

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

        public DataSet ProductsGet(int id)
        {
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("[product].[sprProductsRead]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intProductID", id);

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

        public string ProductsUpdate(Products products, int id)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[product].[sprProductsUpdate]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intProductID", id);
                com.Parameters.AddWithValue("@strProductName", products.strProductName);
                com.Parameters.AddWithValue("@strDescription", products.strDescription);
                com.Parameters.AddWithValue("@intCategoryID", products.intCategoryID);
                com.Parameters.AddWithValue("@decCostPrice", products.decCostPrice);
                com.Parameters.AddWithValue("@decPrice", products.decPrice);
                com.Parameters.AddWithValue("@intSupplierID", products.intSupplierID);
                com.Parameters.AddWithValue("@intCreatedBy", products.intCreatedBy);

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

        public string ProductsDelete(int id)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[product].[sprProductsDelete]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intProductID", id);

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
