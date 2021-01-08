using System;
using System.Collections.Generic;

#nullable disable

namespace OnceDev.Training.Domain
{
    public class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
