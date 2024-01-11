using Microsoft.EntityFrameworkCore;
using MvcAppSales.Data;
using MvcAppSales.Models;

namespace MvcAppSales.Services
{
    public class SalesRecordService(MvcAppSalesContext context)
    {
        private readonly MvcAppSalesContext _context = context;

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var query = _context.SalesRecord
                .Include(s => s.Seller)
                .Include(s => s.Seller.Department)
                .AsQueryable();

            if (minDate.HasValue)
            {
                query = query.Where(s => s.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                query = query.Where(s => s.Date <= maxDate.Value);
            }

            return await query
                .OrderByDescending(s => s.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var query = _context.SalesRecord
                .Include(s => s.Seller)
                .Include(s => s.Seller.Department)
                .AsQueryable();

            if (minDate.HasValue)
            {
                query = query.Where(s => s.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                query = query.Where(s => s.Date <= maxDate.Value);
            }

            return await query
                .OrderByDescending(s => s.Date)
                .GroupBy(s => s.Seller.Department)
                .ToListAsync();
        }
    }
}
