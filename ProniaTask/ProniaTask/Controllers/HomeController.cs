namespace ProniaTask.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Sliders = await _db.Sliders.Take(2).ToListAsync(),
                Products=await _db.Products.Include(p=>p.ProductImages).ToListAsync()
            };
            
            return View(homeVM);
        }
    }
}
