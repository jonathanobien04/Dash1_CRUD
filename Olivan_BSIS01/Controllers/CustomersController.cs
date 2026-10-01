using Microsoft.AspNetCore.Mvc;
using Olivan_ENTPROG___CRUD.Data;
using Olivan_ENTPROG___CRUD.Models;

namespace Olivan_ENTPROG___CRUD.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomersController(ApplicationDbContext db)
        {
            _db = db;
        }

        // LIST ALL CUSTOMERS
        public IActionResult Index()
        {
            var customers = _db.Customers.ToList();
            return View(customers);
        }

        // SHOW ADD FORM
        public IActionResult Create()
        {
            return View();
        }

        // SAVE NEW CUSTOMER
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // SHOW EDIT FORM
        public IActionResult Edit(int id)
        {
            var customer = _db.Customers.Find(id);

            if (customer == null)
            {
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // SAVE EDITED CUSTOMER
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            _db.Customers.Update(customer);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // DELETE CUSTOMER
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