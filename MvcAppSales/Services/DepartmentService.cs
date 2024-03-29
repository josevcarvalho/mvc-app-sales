﻿using Microsoft.EntityFrameworkCore;
using MvcAppSales.Data;
using MvcAppSales.Models;

namespace MvcAppSales.Services
{
    public class DepartmentService(MvcAppSalesContext context)
    {
        private readonly MvcAppSalesContext _context = context;

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(d => d.Name).ToListAsync();
        }
    }
}