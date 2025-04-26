/******************************************************************************
 * Author:      Likhon
 * Created:     April 25, 2025
 * Description: Categories Interface
 ******************************************************************************/

using System.Data;
using ShopManagement.Models;

namespace ShopManagement.Interfaces.Category
{
    public interface ICategoriesRepository
    {
        public string CategoriesPost(Categories categories);
        public DataSet CategoriesGet();
        public DataSet CategoriesGet(int id);
        public string CategoriesUpdate(Categories categories, int id);
        public string CategoriesDelete(int id);
    }
}
