using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7Assignment.Models.ViewModels
{
    public class PageInfo
    {
        //Stores page specific info that is used in page navigation
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set;}
        public int CurrentPage { get; set; }

        //Figure out how many pages are needed
        public int TotalPages => (int) Math.Ceiling((double)TotalNumBooks / BooksPerPage);
    }
}
