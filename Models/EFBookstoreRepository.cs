using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    // This is the repository class for the books
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext context { get; set; }

        public EFBookstoreRepository(BookstoreContext c)
        {
            context = c;
        }

        public IQueryable<Book> Books => context.Books;

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
