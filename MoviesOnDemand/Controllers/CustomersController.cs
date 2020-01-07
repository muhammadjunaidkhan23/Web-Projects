﻿using MoviesOnDemand.Models;
using MoviesOnDemand.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesOnDemand.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer{Name="Muhammad Junaid Khan",id=1},
                new Customer{Name="Sardar Mudassar",id=2}
            };
            var ViewModel = new RandomMovieViewModel()
            {
                Customers = customers
            };
            return View(ViewModel);
        }
        public ActionResult Edit(int id)
        {
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (id == null)
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            {
                return HttpNotFound();

            }
            else
            {
                var customers = new List<Customer>
            {
                new Customer{Name="Muhammad Junaid Khan",id=1},
                new Customer{Name="Sardar Mudassar",id=2}
            };
                var aj = "";
                foreach (var item in customers)
                {
                    if (item.id == id)
                    {
                        aj = item.Name;
                    }
                }
                if (String.IsNullOrWhiteSpace(aj))
                {
                    return View("No Such Record is found");
                }
                else
                {
                    return View(aj);
                }
            }
            
        }
    }
}