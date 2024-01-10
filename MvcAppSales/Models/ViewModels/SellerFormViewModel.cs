namespace MvcAppSales.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; } = default!;
        public required ICollection<Department> Departments { get; set; }
    }
}
