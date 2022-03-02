using Microsoft.AspNetCore.Mvc;
using Mission7Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7Assignment.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repo { get; set; }
        private Cart cart { get; set; }

        public PurchaseController(IPurchaseRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Purchase puchase)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart has no books in it.");
            }

            if (ModelState.IsValid)
            {
                puchase.Lines = cart.Items.ToArray();
                repo.SavePurchase(puchase);
                cart.ClearCart();

                return RedirectToPage("/PurchaseConfirmation");
            }
            else
            {
                return View();
            }
        }
    }
}
