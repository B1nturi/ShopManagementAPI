/******************************************************************************
 * Author:      Likhon
 * Created:     April 25, 2025
 * Description: Suppliers API
 ******************************************************************************/

using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ShopManagement.Interfaces.Customer;
using ShopManagement.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository custRepo;
        public CustomersController(ICustomersRepository custRepo)
        {
            this.custRepo = custRepo;
        }
        string msg = string.Empty;
        // GET: api/<CustomersController>
        [HttpGet]
        public List<Customers> Get()
        {
            try
            {
                Customers employees = new Customers();
                DataSet ds = custRepo.CustomersGet();
                List<Customers> list = new List<Customers>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new Customers
                    {
                        intCustomerID = Convert.ToInt32(dr["intCustomerID"]),
                        strCustomerName = dr["strCustomerName"].ToString(),
                        strAddress = dr["strAddress"].ToString(),
                        strEmail = dr["strEmail"].ToString(),
                        strPhone = dr["strPhone"].ToString(),
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return new List<Customers>();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public List<Customers> Get(int id)
        {
            try
            {
                Customers employees = new Customers();
                DataSet ds = custRepo.CustomersGet(id);
                List<Customers> list = new List<Customers>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new Customers
                    {
                        intCustomerID = Convert.ToInt32(dr["intCustomerID"]),
                        strCustomerName = dr["strCustomerName"].ToString(),
                        strAddress = dr["strAddress"].ToString(),
                        strEmail = dr["strEmail"].ToString(),
                        strPhone = dr["strPhone"].ToString(),
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return new List<Customers>();
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] Customers customers)
        {
            string msg = string.Empty;
            try
            {
                msg = custRepo.CustomersPost(customers);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customers customers)
        {
            string msg = string.Empty;
            try
            {
                msg = custRepo.CustomersUpdate(customers, id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                msg = custRepo.CustomersDelete(id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }
    }
}
