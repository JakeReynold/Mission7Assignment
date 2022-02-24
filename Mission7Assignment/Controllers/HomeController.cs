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

        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            //Determines how many books are displayed on each page
            int pageSize = 10;

            //Creates a BooksViewModel variable with the IQueryable object and the PageInfo class object
            var x = new BooksViewModel
            {
                //Displays each book, makes it possible to display books by category
                Books = repo.Books
                .Where(b => b.Category == bookCategory || bookCategory == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                //Changes the button structure so that it creates only enough buttons for the category selected
                PageInfo = new PageInfo
                {
                    TotalNumBooks = 
                        (bookCategory == null
                            ? repo.Books.Count()
                            : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }

            };

            //Passes the BooksViewModel variable to the Index page.
            return View(x);
        }
    }
}
