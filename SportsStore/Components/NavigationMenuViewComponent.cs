using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SportsStore.Models;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent: ViewComponent
    {
        private ApplicationDbContext _context;

        public NavigationMenuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = HttpContext.Request.Query["category"].ToString();
            return View(_context.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)
            );
        }
    }
}