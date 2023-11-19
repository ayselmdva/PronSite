using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ProniaTask.Controllers
{
    public class ShopController : Controller
    {
        private AppDbContext _db;
        public ShopController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(int id)
        {
            Product? currentProduct = await _db.Products.Include(c => c.Category).Include(img => img.ProductImages).Include(pt => pt.ProductTags).ThenInclude(pt => pt.Tag).FirstOrDefaultAsync(p => p.Id == id);
            if (currentProduct == null)
            {
                return NotFound();
            }

            List<Product> relatedProducts = await _db.Products.Where(p => p.CategoryId == currentProduct.CategoryId).Take(3).ToListAsync();

            ProductDetailVM productDetailVM = new ProductDetailVM()
            {
                CurrentProduct = currentProduct,
                RelatedProducts = relatedProducts
            };
            return View(productDetailVM);
        }
    }
}
