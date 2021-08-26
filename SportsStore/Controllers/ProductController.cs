using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;
        public int PageSize = 1;

        public ProductController(ApplicationDbContext cxt)
        {
            // _repository = repository;
            _context = cxt;
        }

        public ViewResult List(string category, int productPage = 1)
        {
            var products = _context.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID);
            return View(new ProductsListViewModel
            {
                Products = products
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = products.Count()
                },
                CurrentCategory = category
            });
        }
    }
}