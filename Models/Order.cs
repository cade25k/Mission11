using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    // Class to hold order personal info
    public class Order
    {
        [Key]
        [BindNever]
        public int OrderId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line.")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter a city.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a state.")]
        public string State { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country.")]
        public string Country { get; set; }

        [BindNever]
        public bool Shipped { get; set; }
    }
}
