using MvcAppSales.Data;
using MvcAppSales.Models;

namespace MvcAppSales.Services
{
    public class DepartmentService(MvcAppSalesContext context)
    {
        private readonly MvcAppSalesContext _context = context;

        public List<Department> FindAll()
        {
            return [.. _context.Department.OrderBy(d => d.Name)];
        }
    }
}
