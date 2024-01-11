using Microsoft.EntityFrameworkCore;
using MvcAppSales.Data;
using MvcAppSales.Models;
using MvcAppSales.Services.Exceptions;

namespace MvcAppSales.Services
{
    public class SellerService(MvcAppSalesContext context)
    {
        private readonly MvcAppSalesContext _context = context;

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller seller)
        {
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller?> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(s => s.Department).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                Seller? seller = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(seller!);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task Update(Seller seller)
        {
            if (!await _context.Seller.AnyAsync(s => s.Id == seller.Id))
                throw new NotFoundException("Id not found");

            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
