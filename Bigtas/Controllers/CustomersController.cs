using Microsoft.AspNetCore.Mvc;
using Crud_Bigtas.Data;
using Crud_Bigtas.Models;

namespace Crud_Bigtas.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomersController(ApplicationDbContext db)
        {
            _db = db;
        }

        // LIST
        public IActionResult Index()
        {
            var customers = _db.Customers.ToList();
            return View(customers);
        }

        // ADD - show form
        public IActionResult Create()
        {
            return View();
        }

        // ADD - save
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // EDIT - show form
        public IActionResult Edit(int id)
        {
            var customer = _db.Customers.Find(id);

            if (customer == null)
                return RedirectToAction("Index");

            return View(customer);
        }

        // EDIT - save changes
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            _db.Customers.Update(customer);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var customer = _db.Customers.Find(id);

            if (customer != null)
            {
                _db.Customers.Remove(customer);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
