using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission7Assignment.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mission7Assignment.Models
{
    //Create a class of carts that are created during the session, that inherit from the Cart class
    public class SessionCart : Cart
    {
        public static Cart GetCart (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();

            cart.Session = session;

            return cart;
        }


        [JsonIgnore]
        public ISession Session { get; set; }

        //Overrides the AddItem method from the Cart class so that it just affects the specified cart
        public override void AddItem(Book book, int qty)
        {
            base.AddItem(book, qty);
            Session.SetJson("Cart", this);
        }

        //Overrides the RemoveItem method from the Cart class
        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            Session.SetJson("Cart", this);
        }

        //Overrides the ClearCart method from the Cart class
        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("Cart");
        }

    }
}
