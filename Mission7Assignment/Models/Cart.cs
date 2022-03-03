using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7Assignment.Models
{
    //Creates the Cart object
    public class Cart
    {
        /*adds a list of items to the cart*/
        public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();

        /*Creates a function to add items to the list in the cart*/
        public virtual void AddItem (Book book, int qty)
        {
            CartLineItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new CartLineItem
                {
                    Book = book,
                    Quantity = qty

                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        //This method removes items from the cart
        public virtual void RemoveItem (Book book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
        }
        
        //Clears all items from the cart
        public virtual void ClearCart()
        {
            Items.Clear();
        }

        //Calculates the total price of each book in the cart, using the quantity of that specific book and the price of an individual book
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }


    public class CartLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}
