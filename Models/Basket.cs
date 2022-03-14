using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{

    // Class that holds cart items
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();
        
        // Add item to cart
        public virtual void AddItem(Book book, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        // Calculate total cost of items in cart
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);
            return sum;
        }

        public virtual void RemoveItem(Book b)
        {
            Items.RemoveAll(x => x.Book.BookId == b.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }
    }

    // Class that represents a cart item
    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
