using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission7Assignment.Infrastructure;
using Mission7Assignment.Models;

namespace Mission7Assignment.Pages
{
    //Creates the models and actions for the razor pages
    public class PurchaseModel : PageModel
    {
        private IBookstoreProjectRepository repo { get; set; }

        public PurchaseModel (IBookstoreProjectRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        //Creates the cart object
        public Cart cart { get; set; }

        //Creates a string that exists the whole session
        public string ReturnUrl { get; set; }

        //Get method for the razor page
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        //Creates the post method, which receives a bookId and the return url string
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            //cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            cart.AddItem(b, 1);

            //HttpContext.Session.SetJson("cart", cart);

            return RedirectToPage(new { ReturnUrl = returnUrl });

        }

        public IActionResult OnPostRemove (int bookId, string returnUrl)
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
