using Microsoft.EntityFrameworkCore;
using MvcAppSales.Data;
using MvcAppSales.Models;
using MvcAppSales.Services.Exceptions;

namespace MvcAppSales.Services
{
    public class SellerService(MvcAppSalesContext context)
    {
        private readonly MvcAppSalesContext _context = context;

        public List<Seller> FindAll()
        {
            return [.. _context.Seller];
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller? FindById(int id)
        {
            return _context.Seller.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
        }

        public void Remove(int id)
        {
            var seller = _context.Seller.Find(id)!;
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }

        public void Update(Seller seller)
        {
            if (!_context.Seller.Any(s => s.Id == seller.Id))
                throw new NotFoundException("Id not found");

            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
