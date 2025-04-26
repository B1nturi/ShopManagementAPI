/******************************************************************************
 * Author:      Likhon
 * Created:     April 23, 2025
 * Description: Categories API
 ******************************************************************************/

using System.Data;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Interfaces;
using ShopManagement.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository catRepo;
        public CategoriesController(ICategoriesRepository catRepo)
        {
            this.catRepo = catRepo;
        }
        string msg = string.Empty;
        // GET: api/<CategoriesController>
        [HttpGet]
        public List<Categories> Get()
        {
            try
            {
                Categories categories = new Categories();
                DataSet ds = catRepo.CategoriesGet();
                List<Categories> list = new List<Categories>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new Categories
                    {
                        intCategoryID = Convert.ToInt32(dr["intCategoryID"]),
                        strCategoryName = dr["strCategoryName"].ToString(),
                        strDescription = dr["strDescription"].ToString(),
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                Console.WriteLine(msg);
            }
            return new List<Categories>();           
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public List<Categories> Get(int id)
        {
            try
            {
                Categories categories = new Categories();
                DataSet ds = catRepo.CategoriesGet(id);
                List<Categories> list = new List<Categories>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new Categories
                    {
                        intCategoryID = Convert.ToInt32(dr["intCategoryID"]),
                        strCategoryName = dr["strCategoryName"].ToString(),
                        strDescription = dr["strDescription"].ToString(),
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                Console.WriteLine(msg);
            }
            return new List<Categories>();
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] Categories categories)
        {
            string msg = string.Empty;
            try
            {
                msg = catRepo.CategoriesPost(categories);
            }
            catch(Exception ex) 
            { 
                msg = ex.Message;
            }
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Categories categories)
        {
            string msg = string.Empty;
            try
            {
                msg = catRepo.CategoriesUpdate(categories, id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                msg = catRepo.CategoriesDelete(id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }
    }
}
