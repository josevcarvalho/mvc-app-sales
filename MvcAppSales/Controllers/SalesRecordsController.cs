using Microsoft.AspNetCore.Mvc;
using MvcAppSales.Services;

namespace MvcAppSales.Controllers
{
    public class SalesRecordsController(SalesRecordService salesRecordService) : Controller
    {
        private readonly SalesRecordService _salesRecordsService = salesRecordService;

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            minDate ??= new DateTime(DateTime.Now.Year, 1, 1);
            maxDate ??= DateTime.Now;

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordsService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            minDate ??= new DateTime(DateTime.Now.Year, 1, 1);
            maxDate ??= DateTime.Now;

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordsService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}
