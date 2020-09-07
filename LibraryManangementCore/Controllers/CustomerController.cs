using LibraryManangementCore.Data.Interface;
using LibraryManangementCore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManangementCore.Controllers 
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IBookRepository _bookRepo;

        public CustomerController(ICustomerRepository customerRepo, IBookRepository bookRepo)
        {
            _customerRepo = customerRepo;
            _bookRepo = bookRepo;
        }

        public IActionResult CustomerList()
        {
            var model = new List<CustomerViewModel>();
            var customers = _customerRepo.GetAll();
            if (customers.Count() == 0)
            {
                return View("Empty");
            }
            foreach (var customer in customers)
            {
                model.Add(new CustomerViewModel
                {
                    Customer = customer,
                    BookCount = _bookRepo.Count(x => x.BorrowerId == customer.CustomerId)
                });
            }
            return View(model);
        }
    }
}
