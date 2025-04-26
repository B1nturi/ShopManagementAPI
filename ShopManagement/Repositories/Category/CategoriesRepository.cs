/******************************************************************************
 * Author:      Likhon
 * Created:     April 23, 2025
 * Description: Database connection and queries for Categories table
 ******************************************************************************/

using Microsoft.Data.SqlClient;
using System.Data;
using ShopManagement.Models;
using ShopManagement.Interfaces.Category;

namespace ShopManagement.Repositories.Category
{
    public class CategoriesRepository : ICategoriesRepository
    {
        SqlConnection con = new SqlConnection(
           "Data Source=192.168.0.111;Initial Catalog=Likhon;User ID=developer;Password=123456;Trust Server Certificate=True");
        public string CategoriesPost(Categories categories)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[product].[sprCategoriesCreate]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@strCategoryName", categories.strCategoryName);
                com.Parameters.AddWithValue("@strDescription", categories.strDescription);

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

        public DataSet CategoriesGet()
        {
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("[product].[sprCategoriesRead]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intCategoryID", null);

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

        public DataSet CategoriesGet(int id)
        {
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("[product].[sprCategoriesRead]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intCategoryID", id);

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

        public string CategoriesUpdate(Categories categories, int id)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[product].[sprCategoriesUpdate]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intCategoryID", id);
                com.Parameters.AddWithValue("@strCategoryName", categories.strCategoryName);
                com.Parameters.AddWithValue("@strDescription", categories.strDescription);

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
        
        public string CategoriesDelete(int id)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[product].[sprCategoriesDelete]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intCategoryID", id);

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
