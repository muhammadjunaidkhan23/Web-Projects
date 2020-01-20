using MoviesOnDemand.Models;
using MoviesOnDemand.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MoviesOnDemand.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customers
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            //return View(customers);
            //var customers = new List<Customer>
            //{
            //    new Customer{Name="Muhammad Junaid Khan",Id=1},
            //    new Customer{Name="Sardar Mudassar",Id=2}
            //};
            var ViewModel = new RandomMovieViewModel()
            {
                Customers = customers
            };
            return View(ViewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
            var cust = new List<Customer>() { new Customer
                {
                    Name = customer.Name,
                    Id = customer.Id,
                    IsSubcribeToNewsLetter = customer.IsSubcribeToNewsLetter,
                    MembershipType = customer.MembershipType
                }
                };
            var ViewModel = new RandomMovieViewModel();
            //#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            //if (id == null)
            //#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
                //{
                //    var customers = new List<Customer>
                //{
                //    new Customer{Name="Muhammad Junaid Khan",Id=1},
                //    new Customer{Name="Sardar Mudassar",Id=2}
                //};
                //    var aj = "";
                //    foreach (var item in customers)
                //    {
                //        if (item.Id == id)
                //        {
                //            aj = item.Name;
                //        }
                //    }

                ViewModel.Customers = cust;
              return View(ViewModel);
        }

    }
}