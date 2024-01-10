using MvcAppSales.Models;
using MvcAppSales.Models.Enums;

namespace MvcAppSales.Data
{
    public class SeedingService(MvcAppSalesContext context)
    {
        private readonly MvcAppSalesContext _context = context;

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return;
            }

            Department[] departments = [
                new(1, "Computers"),
                new(2, "Electronics"),
                new(3, "Fashion"),
                new(4, "Books")
            ];

            Seller[] sellers = [
                new(1, "Alicia Fernandes", "afernandes@gmail.com", new(1998, 4, 21), 1000.0, departments[0]),
                new(2, "Carlos Augusto", "cagusto@gmail.com", new(1978, 6, 1), 3500.0, departments[1]),
                new(3, "Joao Pereira", "jpereira@gmail.com", new(1965, 8, 15), 2500.0, departments[2]),
                new(4, "Sergio Fagundes", "sfagundes@gmail.com", new(1988, 9, 30), 1500.0, departments[3]),
                new(5, "Fabio Andrade", "fandrade@gmail.com", new(2000, 5, 6), 3000.0, departments[2]),
                new(6, "Amanda Silva", "asilva@gmail.com", new(1980, 1, 4), 2000.0, departments[0])
            ];

            SalesRecord[] sales = [
                new SalesRecord(1, new DateTime(2023, 09, 25), 11000.0, SaleStatus.Billed, sellers[0]),
                new SalesRecord(2, new DateTime(2023, 09, 4), 7000.0, SaleStatus.Billed, sellers[4]),
                new SalesRecord(3, new DateTime(2023, 09, 13), 4000.0, SaleStatus.Canceled, sellers[3]),
                new SalesRecord(4, new DateTime(2023, 09, 1), 8000.0, SaleStatus.Billed, sellers[0]),
                new SalesRecord(5, new DateTime(2023, 09, 21), 3000.0, SaleStatus.Billed, sellers[2]),
                new SalesRecord(6, new DateTime(2023, 09, 15), 2000.0, SaleStatus.Billed, sellers[0]),
                new SalesRecord(7, new DateTime(2023, 09, 28), 13000.0, SaleStatus.Billed, sellers[1]),
                new SalesRecord(8, new DateTime(2023, 09, 11), 4000.0, SaleStatus.Billed, sellers[3]),
                new SalesRecord(9, new DateTime(2023, 09, 14), 11000.0, SaleStatus.Pending, sellers[5]),
                new SalesRecord(10, new DateTime(2023, 09, 7), 9000.0, SaleStatus.Billed, sellers[5]),
                new SalesRecord(11, new DateTime(2023, 09, 13), 6000.0, SaleStatus.Billed, sellers[1]),
                new SalesRecord(12, new DateTime(2023, 09, 25), 7000.0, SaleStatus.Pending, sellers[2]),
                new SalesRecord(13, new DateTime(2023, 09, 29), 10000.0, SaleStatus.Billed, sellers[3]),
                new SalesRecord(14, new DateTime(2023, 09, 4), 3000.0, SaleStatus.Billed, sellers[4]),
                new SalesRecord(15, new DateTime(2023, 09, 12), 4000.0, SaleStatus.Billed, sellers[0]),
                new SalesRecord(16, new DateTime(2023, 10, 5), 2000.0, SaleStatus.Billed, sellers[3]),
                new SalesRecord(17, new DateTime(2023, 10, 1), 12000.0, SaleStatus.Billed, sellers[0]),
                new SalesRecord(18, new DateTime(2023, 10, 24), 6000.0, SaleStatus.Billed, sellers[2]),
                new SalesRecord(19, new DateTime(2023, 10, 22), 8000.0, SaleStatus.Billed, sellers[4]),
                new SalesRecord(20, new DateTime(2023, 10, 15), 8000.0, SaleStatus.Billed, sellers[5]),
                new SalesRecord(21, new DateTime(2023, 10, 17), 9000.0, SaleStatus.Billed, sellers[1]),
                new SalesRecord(22, new DateTime(2023, 10, 24), 4000.0, SaleStatus.Billed, sellers[3]),
                new SalesRecord(23, new DateTime(2023, 10, 19), 11000.0, SaleStatus.Canceled, sellers[1]),
                new SalesRecord(24, new DateTime(2023, 10, 12), 8000.0, SaleStatus.Billed, sellers[4]),
                new SalesRecord(25, new DateTime(2023, 10, 31), 7000.0, SaleStatus.Billed, sellers[2]),
                new SalesRecord(26, new DateTime(2023, 10, 6), 5000.0, SaleStatus.Billed, sellers[3]),
                new SalesRecord(27, new DateTime(2023, 10, 13), 9000.0, SaleStatus.Pending, sellers[0]),
                new SalesRecord(28, new DateTime(2023, 10, 7), 4000.0, SaleStatus.Billed, sellers[2]),
                new SalesRecord(29, new DateTime(2023, 10, 23), 12000.0, SaleStatus.Billed, sellers[4]),
                new SalesRecord(30, new DateTime(2023, 10, 12), 5000.0, SaleStatus.Billed, sellers[1])
            ];

            _context.Department.AddRange(departments);
            _context.Seller.AddRange(sellers);
            _context.SalesRecord.AddRange(sales);

            _context.SaveChanges();
        }
    }
}
