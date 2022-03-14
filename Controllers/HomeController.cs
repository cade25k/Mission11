using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission7.Models;
using Mission7.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        // Constructor
        public HomeController(IBookstoreRepository br)
        {
            repo = br;
        }

        // Get Index page
        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int pageSize = 10;
            var bvm = new BooksViewModel
            {
                // Get Books filtered by category and seperate out into pages
                Books = repo.Books
                    .Where(b => b.Category == bookCategory || bookCategory == null)
                    .OrderBy(b => b.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                // Determine number of pages
                PageInfo = new PageInfo
                {
                    TotalBooks = 
                        (bookCategory == null 
                        ? repo.Books.Count()
                        : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(bvm);
        }
    }
}
