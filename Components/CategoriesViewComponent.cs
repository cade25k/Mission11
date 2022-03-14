using Microsoft.AspNetCore.Mvc;
using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8.Components
{
    // View Component Class to get the categories
    public class CategoriesViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }

        public CategoriesViewComponent(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
