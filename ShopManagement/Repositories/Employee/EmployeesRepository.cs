/******************************************************************************
 * Author:      Likhon
 * Created:     April 24, 2025
 * Description: Database connection and queries for Employees table
 ******************************************************************************/

using Microsoft.Data.SqlClient;
using System.Data;
using ShopManagement.Models;
using ShopManagement.Interfaces;

namespace ShopManagement.Repositories.Employee
{
    public class EmployeesRepository : IEmployeesRepository
    {
        SqlConnection con = new SqlConnection(
           "Data Source=192.168.0.111;Initial Catalog=Likhon;User ID=developer;Password=123456;Trust Server Certificate=True");

        public string EmployeesPost(Employees employees)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[hr].[sprEmployeesCreate]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@strFullName", employees.strFullName);
                com.Parameters.AddWithValue("@strPhone", employees.strPhone);
                com.Parameters.AddWithValue("@strAddress", employees.strAddress);
                com.Parameters.AddWithValue("@strPosition", employees.strPosition);
                com.Parameters.AddWithValue("@dtrHireDate", employees.dtrHireDate);

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

        public DataSet EmployeesGet()
        {
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("[hr].[sprEmployeesRead]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intEmployeeID", null);

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

        public DataSet EmployeesGet(int id)
        {
            string msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("[hr].[sprEmployeesRead]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intEmployeeID", id);

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

        public string EmployeesUpdate(Employees employees, int id)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[hr].[sprEmployeesUpdate]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intEmployeeID", id);
                com.Parameters.AddWithValue("@strFullName", employees.strFullName);
                com.Parameters.AddWithValue("@strPhone", employees.strPhone);
                com.Parameters.AddWithValue("@strAddress", employees.strAddress);
                com.Parameters.AddWithValue("@strPosition", employees.strPosition);
                com.Parameters.AddWithValue("@dtrHireDate", employees.dtrHireDate);

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
        
        public string EmployeesDelete(int id)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("[hr].[sprEmployeesDelete]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@intEmployeeID", id);

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
