using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission7.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mission7.Models
{
    // Class to keep basket in a session
    public class SessionBasket : Basket
    {
        [JsonIgnore]
        public ISession Session { get; set; }

        public static Basket GetBasket (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();
            basket.Session = session;
            return basket;
        }

        public override void AddItem(Book book, int qty)
        {
            base.AddItem(book, qty);
            Session.SetJson("Basket", this);
        }

        public override void RemoveItem(Book b)
        {
            base.RemoveItem(b);
            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }

    }
}
