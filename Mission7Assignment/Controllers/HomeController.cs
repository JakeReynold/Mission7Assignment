using Microsoft.AspNetCore.Mvc;
using Mission7Assignment.Models;
using Mission7Assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7Assignment.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreProjectRepository repo;

        public HomeController (IBookstoreProjectRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(int pageNum = 1)
        {
            //Determines how many books are displayed on each page
            int pageSize = 10;

            //Creates a BooksViewModel variable with the IQueryable object and the PageInfo class object
            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }

            };

            //Passes the BooksViewModel variable to the Index page.
            return View(x);
        }
    }
}
