using Microsoft.AspNetCore.Mvc;
using Mission7Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7Assignment.Components
{
    //Creates a view component to make a list of categories the user can use for navigation
    public class CategoriesViewComponent : ViewComponent
    {
        private IBookstoreProjectRepository repo { get; set; }

        public CategoriesViewComponent (IBookstoreProjectRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            //Pulls the categories, then displays them 
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
