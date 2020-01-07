using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoviesOnDemand.Models;
using MoviesOnDemand.ViewModels;

namespace MoviesOnDemand.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/With parameters
        //public ActionResult Index(int? pageIndex,string sortBy)
        //{
        //    if(!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "NAME";
        //    }
        //    return Content(String.Format("PageIndex = {0}& sort by={1}", pageIndex, sortBy));
        //}

        // GET :Movies
        public ActionResult Index()
        {
            var movie = new List<Movie>
            {
                new Movie{Name="Doctor Strange",Id=1},
                new Movie{Name="Passanger",Id=2}
            };
            var movieModel = new RandomMovieViewModel
            {
                Movies = movie
            };
            return View(movieModel);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            //FOR THE MOVIES NAME
            var movie = new Movie() { Name = "Docter Strange" };

            //FOR LIST OF CUSTOMER
            var customers = new List<Customer>
            {
                new Customer{Name="Muhammad Junaid Khan"},
                new Customer{Name="Sardar Mudassar"}
            };

            //INITIALIZING VIEW MODEL
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);

            //return Content("HELLO WORLD");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home",new {page=1,sortBy="Junaid"});

        }

        public ActionResult Edit(int id)
        {
            return Content("ID :"+id);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year+"/"+month);
        }
     
    }
}