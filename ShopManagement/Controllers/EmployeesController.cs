/******************************************************************************
 * Author:      Likhon
 * Created:     April 24, 2025
 * Description: Employees API
 ******************************************************************************/

using Microsoft.AspNetCore.Mvc;
using System.Data;
using ShopManagement.Models;
using ShopManagement.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesRepository empRepo;
        public EmployeesController(IEmployeesRepository empRepo)
        {
            this.empRepo = empRepo;
        }
        string msg = string.Empty;
        // GET: api/<EmployeesController>
        [HttpGet]
        public List<Employees> Get()
        {
            try
            {
                Employees employees = new Employees();
                DataSet ds = empRepo.EmployeesGet();
                List<Employees> list = new List<Employees>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new Employees
                    {
                        intEmployeeID = Convert.ToInt32(dr["intEmployeeID"]),
                        strFullName = dr["strFullName"].ToString(),
                        strAddress = dr["strAddress"].ToString(),
                        strPosition = dr["strPosition"].ToString(),
                        strPhone = dr["strPhone"].ToString(),
                        dtrHireDate = dr["dtrHireDate"].ToString(),
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                Console.WriteLine(msg);
            }
            return new List<Employees>();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public List<Employees> Get(int id)
        {
            try
            {
                Employees employees = new Employees();
                DataSet ds = empRepo.EmployeesGet(id);
                List<Employees> list = new List<Employees>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new Employees
                    {
                        intEmployeeID = Convert.ToInt32(dr["intEmployeeID"]),
                        strFullName = dr["strFullName"].ToString(),
                        strAddress = dr["strAddress"].ToString(),
                        strPosition = dr["strPosition"].ToString(),
                        strPhone = dr["strPhone"].ToString(),
                        dtrHireDate = dr["dtrHireDate"].ToString(),
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                Console.WriteLine(msg);
            }
            return new List<Employees>();
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] Employees employees)
        {
            string msg = string.Empty;
            try
            {
                msg = empRepo.EmployeesPost(employees);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employees employees)
        {
            string msg = string.Empty;
            try
            {
                msg = empRepo.EmployeesUpdate(employees, id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                msg = empRepo.EmployeesDelete(id);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }
    }
}
