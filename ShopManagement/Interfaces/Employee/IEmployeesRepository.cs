/******************************************************************************
 * Author:      Likhon
 * Created:     April 25, 2025
 * Description: Employees Interface
 ******************************************************************************/

using ShopManagement.Models;
using System.Data;

namespace ShopManagement.Interfaces.Employee
{
    public interface IEmployeesRepository
    {
        public string EmployeesPost(Employees employees);
        public DataSet EmployeesGet();
        public DataSet EmployeesGet(int id);
        public string EmployeesUpdate(Employees employees, int id);
        public string EmployeesDelete(int id);
    }
}
