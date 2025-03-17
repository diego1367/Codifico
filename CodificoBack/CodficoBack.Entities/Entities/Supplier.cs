using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodficoBack.Entities.Entities
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string ContactName { get; set; } = string.Empty;
        public string ContactTitle { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Fax { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
