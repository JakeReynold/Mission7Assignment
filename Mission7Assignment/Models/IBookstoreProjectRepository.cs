using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7Assignment.Models
{
    //Creates interface for repository to inherit from
    public interface IBookstoreProjectRepository
    {
        IQueryable<Book> Books { get; }
    }
}
