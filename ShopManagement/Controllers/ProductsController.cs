using System.Data;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Interfaces;
using ShopManagement.Models;
using ShopManagement.Repositories.Product;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository prodRepo;
        public ProductsController(IProductsRepository prodRepo)
        {
            this.prodRepo = prodRepo;
        }
        string msg = string.Empty;
        // GET: api/<ProductController>
        [HttpGet]
        public List<Products> Get()
        {
            try
            {
                Products products = new Products();
                DataSet ds = prodRepo.ProductsGet();
                List<Products> list = new List<Products>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    list.Add(new Products
                    {
                        intProductID = Convert.ToInt32(dr["intProductID"]),
                        strProductName = dr["strProductName"].ToString(),
                        strDescription = dr["strDescription"].ToString(),
                        intCategoryID = Convert.ToInt32(dr["intCategoryID"]),
                        decCostPrice = Convert.ToDecimal(dr["decCostPrice"]),
                        decPrice = Convert.ToDecimal(dr["decPrice"]),
                        intSupplierID = Convert.ToInt32(dr["intSupplierID"]),
                        intCreatedBy = Convert.ToInt32(dr["intCreatedBy"]),
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return new List<Products>();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public List<Products> Get(int id)
        {
            try
            {
                Products products = new Products();
                DataSet ds = prodRepo.ProductsGet(id);
                List<Products> list = new List<Products>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new Products
                    {
                        intProductID = Convert.ToInt32(dr["intProductID"]),
                        strProductName = dr["strProductName"].ToString(),
                        strDescription = dr["strDescription"].ToString(),
                        intCategoryID = Convert.ToInt32(dr["intCategoryID"]),
                        decCostPrice = Convert.ToDecimal(dr["decCostPrice"]),
                        decPrice = Convert.ToDecimal(dr["decPrice"]),
                        intSupplierID = Convert.ToInt32(dr["intSupplierID"]),
                        intCreatedBy = Convert.ToInt32(dr["intCreatedBy"]),
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return new List<Products>();
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] Products products)
        {
            string msg = string.Empty;
            try
            {
                msg = prodRepo.ProductsPost(products);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Products products)
        {
            string msg = string.Empty;
            try
            {
                msg = prodRepo.ProductsUpdate(products, id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                msg = prodRepo.ProductsDelete(id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }
    }
}
