using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    //Repo for orders
    public class EFOrderRepository : IOrderRepository
    {

        private BookstoreContext context;
        public EFOrderRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Order> Orders => context.Orders.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveOrder(Order o)
        {
            context.AttachRange(o.Lines.Select(x => x.Book));

            if (o.OrderId == 0)
            {
                context.Orders.Add(o);
            }

            context.SaveChanges();
        }
    }
}
