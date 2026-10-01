using Microsoft.AspNetCore.Mvc;
using aspversion1.Data;
using aspversion1.Models;

namespace aspversion1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // SHOW PRODUCTS
        public IActionResult Index()
        {
            var products = _db.Products.ToList();
            return View(products);
        }

        // SHOW ADD FORM
        public IActionResult Create()
        {
            return View();
        }

        // SAVE NEW PRODUCT
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // SHOW EDIT FORM
        public IActionResult Edit(int id)
        {
            var product = _db.Products.Find(id);

            if (product == null)
                return RedirectToAction("Index");

            return View(product);
        }

        // SAVE EDITED PRODUCT
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // DELETE PRODUCT
        public IActionResult Delete(int id)
        {
            var product = _db.Products.Find(id);

            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
