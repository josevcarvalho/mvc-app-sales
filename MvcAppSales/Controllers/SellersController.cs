using Microsoft.AspNetCore.Mvc;
using MvcAppSales.Services;
using MvcAppSales.Models;
using MvcAppSales.Models.ViewModels;
using MvcAppSales.Services.Exceptions;

namespace MvcAppSales.Controllers
{
    public class SellersController(SellerService sellerService, DepartmentService departmentService) : Controller
    {
        private readonly SellerService _sellerService = sellerService;
        private readonly DepartmentService _departmentService = departmentService;

        public IActionResult Index()
        {
            List<Seller> list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var viewModel = new SellerFormViewModel { Departments = _departmentService.FindAll() };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            Seller? seller;

            if (id == null || (seller = _sellerService.FindById(id.Value)) == null)
                return NotFound();

            return View(seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            Seller? seller;

            if (id == null || (seller = _sellerService.FindById(id.Value)) == null)
                return NotFound();

            return View(seller);
        }

        public IActionResult Edit(int? id)
        {
            Seller? seller;

            if (id == null || (seller = _sellerService.FindById(id.Value)) == null)
                return NotFound();

            List<Department> departments = _departmentService.FindAll();
            SellerFormViewModel viewModel = new() { Seller = seller, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
                return BadRequest();

            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }

    }
}
