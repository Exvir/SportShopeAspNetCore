using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


// Класс для создания запросов в базу данных, скрывает объект контекта в приватном поле
namespace SportsStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;

        public EFProductRepository(ApplicationDbContext cxt)
        {
            _context = cxt;
        }

        public IQueryable<Product> Products => _context.Products;
    }
}