using Microsoft.AspNetCore.Mvc;
using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Controllers
{
    //Order controller when checking out
    public class OrderController : Controller
    {
        private IOrderRepository repo { get; set; }
        private Basket basket { get; set; }

        public OrderController(IOrderRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order o)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Your cart is empty.");
            }

            if (ModelState.IsValid)
            {
                o.Lines = basket.Items.ToArray();
                repo.SaveOrder(o);
                basket.ClearBasket();

                return RedirectToPage("/Confirmation");
            }
            else
            {
                return View();
            }
        }
    }
}
