using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models.ViewModels
{
    // This class stores info regarding number of pages to be shown
    public class PageInfo
    {
        public int TotalBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int) Math.Ceiling((double) TotalBooks / BooksPerPage);
    }
}
