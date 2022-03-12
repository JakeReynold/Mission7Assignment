using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7Assignment.Models
{
    //Creates the repository
    public class EFBookstoreProjectRepository : IBookstoreProjectRepository
    {
        //Creates and passes the context object
        private BookstoreContext context { get; set; }

        public EFBookstoreProjectRepository (BookstoreContext temp)
        {
            context = temp;
        }

        //Creates the IQueryable object
        public IQueryable<Book> Books => context.Books;

        //Creates methods for Saving, Creating, and Deleting books.
        public void SaveBook(Book b)
        {
            context.SaveChanges();
        }

        public void CreateBook(Book b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteBook(Book b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
    }
}
