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
        //Creates an instance of the IPurchaseRepository
        private IPurchaseRepository repo { get; set; }

        //Instantiates a cart object
        private Cart cart { get; set; }

        //Class constructor
        public PurchaseController(IPurchaseRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        //Action that will take the user to the checkout page
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        //Action that will submit the user's information from the form
        [HttpPost]
        public IActionResult Checkout(Purchase puchase)
        {
            //Stops the user from submitting an empty form
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart has no books in it.");
            }

            //If the model is valid, the form is submitted and the user is taken to the confirmation page
            if (ModelState.IsValid)
            {
                puchase.Lines = cart.Items.ToArray();
                repo.SavePurchase(puchase);
                cart.ClearCart();

                return RedirectToPage("/PurchaseConfirmation");
            }
            else
            //if the model is invalid, it returns the user back to the view
            {
                return View();
            }
        }
    }
}
