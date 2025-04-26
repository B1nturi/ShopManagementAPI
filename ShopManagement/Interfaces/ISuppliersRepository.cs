using ShopManagement.Models;
using System.Data;

namespace ShopManagement.Interfaces
{
    public interface ISuppliersRepository
    {
        public string SuppliersPost(Suppliers suppliers);
        public DataSet SuppliersGet();
        public DataSet SuppliersGet(int id);
        public string SuppliersUpdate(Suppliers suppliers, int id);
        public string SuppliersDelete(int id);
    }
}
