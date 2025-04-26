/******************************************************************************
 * Author:      Likhon
 * Created:     April 26, 2025
 * Description: Sales API Controller
 ******************************************************************************/

using System.Data;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Interfaces.Sale;
using ShopManagement.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesRepository saleRepo;
        public SalesController(ISalesRepository saleRepo)
        {
            this.saleRepo = saleRepo;
        }
        string msg = string.Empty;
        // GET: api/<SalesController>
        [HttpGet]
        public List<Sales> Get()
        {
            try
            {
                Sales sales = new Sales();
                DataSet ds = saleRepo.SalesGet();
                List<Sales> list = new List<Sales>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    list.Add(new Sales
                    {
                        intSaleId = Convert.ToInt32(dr["intSaleId"]),
                        intCustomerID = Convert.ToInt32(dr["intCustomerID"]),
                        intEmployeeID = Convert.ToInt32(dr["intEmployeeID"]),
                        decTotalAmount = Convert.ToDecimal(dr["decTotalAmount"]),
                        dtrSaleDate = dr["dtrSaleDate"].ToString(),
                        strPaymentMethod = dr["strPaymentMethod"].ToString(),
                        strPaymentStatus = dr["strPaymentStatus"].ToString(),
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return new List<Sales>();
        }

        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        public List<Sales> Get(int id)
        {
            try
            {
                Sales sales = new Sales();
                DataSet ds = saleRepo.SalesGet(id);
                List<Sales> list = new List<Sales>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    list.Add(new Sales
                    {
                        intSaleId = Convert.ToInt32(dr["intSaleId"]),
                        intCustomerID = Convert.ToInt32(dr["intCustomerID"]),
                        intEmployeeID = Convert.ToInt32(dr["intEmployeeID"]),
                        decTotalAmount = Convert.ToDecimal(dr["decTotalAmount"]),
                        dtrSaleDate = dr["dtrSaleDate"].ToString(),
                        strPaymentMethod = dr["strPaymentMethod"].ToString(),
                        strPaymentStatus = dr["strPaymentStatus"].ToString(),
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return new List<Sales>();
        }

        // POST api/<SalesController>
        [HttpPost]
        public void Post([FromBody] Sales sales)
        {
            try
            {
                msg = saleRepo.SalesPost(sales);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }

        // PUT api/<SalesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Sales sales)
        {
            try
            {
                msg = saleRepo.SalesUpdate(sales, id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                msg = saleRepo.SalesDelete(id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }
    }
}
