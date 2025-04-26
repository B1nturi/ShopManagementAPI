/******************************************************************************
 * Author:      Likhon
 * Created:     April 24, 2025
 * Description: Suppliers Model
 ******************************************************************************/

using Microsoft.AspNetCore.Mvc;
using System.Data;
using ShopManagement.Models;
using ShopManagement.Repositories.Supplier;
using ShopManagement.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {

        private readonly ISuppliersRepository suppRepo;
        public SuppliersController(ISuppliersRepository suppRepo)
        {
            this.suppRepo = suppRepo;
        }
        string msg = string.Empty;

        // GET: api/<SuppliersController>
        [HttpGet]
        public List<Suppliers> Get()
        {
            try
            {
                Suppliers suppliers = new Suppliers();
                DataSet ds = suppRepo.SuppliersGet();
                List<Suppliers> list = new List<Suppliers>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new Suppliers
                    {
                        intSupplierID = Convert.ToInt32(dr["intSupplierID"]),
                        strSupplierName = dr["strSupplierName"].ToString(),
                        strContactName = dr["strContactName"].ToString(),
                        strPhone = dr["strPhone"].ToString(),
                        strAddress = dr["strAddress"].ToString(),
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                Console.WriteLine(msg);
            }
            return new List<Suppliers>();
        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")]
        public List<Suppliers> Get(int id)
        {
            try
            {
                Suppliers suppliers = new Suppliers();
                DataSet ds = suppRepo.SuppliersGet(id);
                List<Suppliers> list = new List<Suppliers>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new Suppliers
                    {
                        intSupplierID = Convert.ToInt32(dr["intSupplierID"]),
                        strSupplierName = dr["strSupplierName"].ToString(),
                        strContactName = dr["strContactName"].ToString(),
                        strPhone = dr["strPhone"].ToString(),
                        strAddress = dr["strAddress"].ToString(),
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                Console.WriteLine(msg);
            }
            return new List<Suppliers>();
        }

        // POST api/<SuppliersController>
        [HttpPost]
        public void Post([FromBody] Suppliers suppliers)
        {
            string msg = string.Empty;
            try
            {
                msg = suppRepo.SuppliersPost(suppliers);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }

        // PUT api/<SuppliersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Suppliers suppliers)
        {
            string msg = string.Empty;
            try
            {
                msg = suppRepo.SuppliersUpdate(suppliers, id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }

        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                msg = suppRepo.SuppliersDelete(id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }
    }
}
