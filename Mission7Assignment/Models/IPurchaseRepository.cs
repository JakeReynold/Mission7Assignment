using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7Assignment.Models
{
    //Creates an interface for the purchase repository to inherit from
    public interface IPurchaseRepository
    {
        public IQueryable<Purchase> Purchases { get; }

        public void SavePurchase(Purchase purchase);
    }
}
