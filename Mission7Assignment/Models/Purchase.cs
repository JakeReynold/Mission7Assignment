using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7Assignment.Models
{
    //This is the model that contains the user information when the user submits a purchase
    public class Purchase
    {
        [Key]
        [BindNever]
        public int PurchaseId { get; set; }

        [BindNever]
        public ICollection<CartLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The first address line is required")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "City name is required")]
        public string City { get; set; }

        [Required(ErrorMessage ="State is required")]
        public string State { get; set; }
        public string Zip { get; set; }

        [Required(ErrorMessage = "Country name is required")]
        public string Country { get; set; }

        [BindNever]
        public bool PurchaseReceived { get; set; }


    }
}
