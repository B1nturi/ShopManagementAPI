using System.Data;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Interfaces.Purchase;
using ShopManagement.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchsesRepository purRepo;
        public PurchasesController(IPurchsesRepository purRepo)
        {
            this.purRepo = purRepo;
        }
        string msg = string.Empty;
        // GET: api/<PurchasesController>
        [HttpGet]
        public List<Purchases> Get()
        {
            try
            {
                DataSet ds = purRepo.PurchasesGet();
                List<Purchases> list = new List<Purchases>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    list.Add(new Purchases
                    {
                        intPurchaseID = Convert.ToInt32(dr["intSaleID"]),
                        intSupplierID = Convert.ToInt32(dr["intCustomerID"]),
                        intEmployeeID = Convert.ToInt32(dr["intEmployeeID"]),
                        decTotalCost = Convert.ToDecimal(dr["decTotalAmount"]),
                        dtrPurchaseDate = dr["dtrSaleDate"].ToString(),
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
            return new List<Purchases>();
        }

        // GET api/<PurchasesController>/5
        [HttpGet("{id}")]
        public List<Purchases> Get(int id)
        {
            try
            {
                DataSet ds = purRepo.PurchasesGet();
                List<Purchases> list = new List<Purchases>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    list.Add(new Purchases
                    {
                        intPurchaseID = Convert.ToInt32(dr["intSaleID"]),
                        intSupplierID = Convert.ToInt32(dr["intCustomerID"]),
                        intEmployeeID = Convert.ToInt32(dr["intEmployeeID"]),
                        decTotalCost = Convert.ToDecimal(dr["decTotalAmount"]),
                        dtrPurchaseDate = dr["dtrSaleDate"].ToString(),
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
            return new List<Purchases>();
        }

        // POST api/<PurchasesController>
        [HttpPost]
        public void Post([FromBody] Purchases purchases)
        {
            try
            {
                msg = purRepo.PurchasesPost(purchases);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }

        // PUT api/<PurchasesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Purchases purchases)
        {
            try
            {
                msg = purRepo.PurchasesUpdate(purchases, id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }

        // DELETE api/<PurchasesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                msg = purRepo.PurchasesDelete(id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }
    }
}
