using Microsoft.AspNetCore.Mvc;
using OnceDev.Training.Domain;
using OnceDev.Training.Infrastructure.Repository;

namespace OnceDev.Training.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.List());
        }

        public IActionResult Create()
        {
            return View(new Customer());
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _repository.Insert(customer);
            return RedirectToAction("Details", new { Id = customer.Id });
        }

        public IActionResult Details(int id)
        {
            return View(_repository.Find(c => c.Id == id));
        }

        public IActionResult Edit(int id)
        {
            return View(_repository.Find(c => c.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (_repository.Update(customer))
                return RedirectToAction("Index");
            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            return View(_repository.Find(c => c.Id == id));
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            if (_repository.Delete(customer))
                return RedirectToAction("Index");
            return View(customer);
        }
    }
}
