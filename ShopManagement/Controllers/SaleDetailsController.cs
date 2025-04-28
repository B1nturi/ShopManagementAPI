/******************************************************************************
 * Author:      Likhon
 * Created:     April 28, 2025
 * Description: SaleDetails API Controller
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
    public class SaleDetailsController : ControllerBase
    {
        private readonly ISaleDetailsRepository saleDRepo;
        public SaleDetailsController(ISaleDetailsRepository saleDRepo)
        {
            this.saleDRepo = saleDRepo;
        }
        string msg = string.Empty;
        // GET: api/<SaleDetailsController>
        [HttpGet]
        public List<SaleDetails> Get()
        {
            try
            {
                DataSet ds = saleDRepo.SaleDetailsGet();
                List<SaleDetails> list = new List<SaleDetails>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    list.Add(new SaleDetails
                    {
                        intSaleDetailsID = Convert.ToInt32(dr["intSaleDetailsID"]),
                        intSaleID = Convert.ToInt32(dr["intSaleID"]),
                        intProductID = Convert.ToInt32(dr["intProductID"]),
                        intQuantity = Convert.ToInt32(dr["intQuantity"]),
                        decUnitPrice = Convert.ToDecimal(dr["decUnitPrice"]),
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return new List<SaleDetails>();
        }

        // GET api/<SaleDetailsController>/5
        [HttpGet("{id}")]
        public List<SaleDetails> Get(int id)
        {
            try
            {
                DataSet ds = saleDRepo.SaleDetailsGet(id);
                List<SaleDetails> list = new List<SaleDetails>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    list.Add(new SaleDetails
                    {
                        intSaleDetailsID = Convert.ToInt32(dr["intSaleDetailsID"]),
                        intSaleID = Convert.ToInt32(dr["intSaleID"]),
                        intProductID = Convert.ToInt32(dr["intProductID"]),
                        intQuantity = Convert.ToInt32(dr["intQuantity"]),
                        decUnitPrice = Convert.ToDecimal(dr["decUnitPrice"]),
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return new List<SaleDetails>();
        }

        // POST api/<SaleDetailsController>
        [HttpPost]
        public void Post([FromBody] SaleDetails saleDetails)
        {
            try
            {
                msg = saleDRepo.SaleDetailsPost(saleDetails);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }

        // PUT api/<SaleDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SaleDetails saleDetails)
        {
            try
            {
                msg = saleDRepo.SaleDetailsUpdate(saleDetails, id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }

        // DELETE api/<SaleDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                msg = saleDRepo.SaleDetailsDelete(id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }
    }
}
